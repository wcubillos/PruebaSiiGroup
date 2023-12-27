using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDotNet.Models.Entities
{
    public class Memployees
    {

        // Añade atributos de datos para mapear las propiedades con los nombres reales en el JSON
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_salary")]
        public string EmployeeSalary { get; set; }

        [JsonProperty("employee_age")]
        public string EmployeeAge { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("employee_salary_year")]
        public string AnnualSalary { get; set; }

    }
}
