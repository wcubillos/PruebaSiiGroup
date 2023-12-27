using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NPOI.POIFS.Crypt.Dsig;
using PruebaDotNet.Models;
using PruebaDotNet.Models.Entities;
using PruebaDotNet.Models.Interface;
using System.Reflection;
using System.Runtime.Serialization;

namespace PruebaDotNet.Controllers
{
    
    public class EmployeeController : Controller
    {
        //Se prepara para ir a la capa de negocios por la información
        private readonly Interoperability _interoperability;


        public EmployeeController(Interoperability Interoperability)
        {
            _interoperability = Interoperability;
        }

        public async Task<IActionResult> Listar()
        {
            var apiData = await _interoperability.Consume();
            var employees = MapToMemployee(apiData);
            return View(employees);
        }



        private List<Memployee> MapToMemployee(List<Memployees> apiData)
        {
            // listado de la apidata
            var mappedEmployees = new List<Memployee>();

            foreach (var item in apiData)
            {
                var mappedEmployee = new Memployee
                {
                    Id = item.Id,
                    EmployeeName = item.EmployeeName,
                    EmployeeSalary = item.EmployeeSalary,
                    EmployeeAge = item.EmployeeAge,
                    ProfileImage = item.ProfileImage,
                };

                // Se multiplica el salario mensual por 12 para obtener el salario anual
                decimal monthlySalary;
                if (decimal.TryParse(item.EmployeeSalary, out monthlySalary))
                {
                    decimal annualSalary = monthlySalary * 12;
                    //mappedEmployee.AnnualSalary = decimal.Parse((monthlySalary * 12).ToString(""));
                    mappedEmployee.AnnualSalary = string.Format("{0:C}", annualSalary); 
                }

                mappedEmployees.Add(mappedEmployee);
            }

            return mappedEmployees;
        }

        //Metodo para la busqueda por empleado
        [HttpPost]
        public async Task<IActionResult> BuscarEmpleado(string employeeId)
        {
            if (string.IsNullOrEmpty(employeeId))
            {
                // Si el campo de búsqueda está vacío, muestra la lista completa de empleados
                return RedirectToAction("Listar");
            }
            else if (int.TryParse(employeeId, out int id))
            {
                // Si se ingresó un ID de empleado válido, busca el empleado por ID
                var apiData = await _interoperability.Consume();
                var employees = MapToMemployee(apiData);
                var employee = employees.FirstOrDefault(e => e.Id == id);

                if (employee != null)
                {
                    // Devuelve los detalles del empleado encontrado
                    return View("Detalles", employee);
                }

            }

            // Redirecciono si el ID no es válido o el empleado no se encuentra
            return RedirectToAction("Listar");
        }

    }
}
