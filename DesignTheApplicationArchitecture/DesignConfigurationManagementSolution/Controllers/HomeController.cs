using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesignConfigurationManagementSolution.Models;
using Microsoft.Extensions.Configuration;

namespace DesignConfigurationManagementSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config) {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Objective1() {
            
            var starship = _config.GetSection("starship").Get<Starship>();

            return View(starship);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
