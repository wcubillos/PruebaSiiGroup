using Microsoft.AspNetCore.Mvc;
using PruebaDotNet.Models;
using PruebaDotNet.Models.Entities;
using System.Diagnostics;

namespace PruebaDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMemployee()
        {
            return View("Employee");
        }

        //[HttpPost]
        //public IActionResult Employee(List<Memployees> employees)
        //{
        //    return PartialView("Employee", employees);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}