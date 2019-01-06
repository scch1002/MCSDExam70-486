using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesignACachingStrategy.Models;

namespace DesignACachingStrategy.Controllers
{
    public class HomeController : Controller
    {
    //  https://docs.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-2.2

        public IActionResult Index()
        {
            return View();
        }

        //  https://docs.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-2.2
        [ResponseCache(NoStore=true, Duration=10)]
        public IActionResult CacheNoStore() 
        {            
            return View();
        }

        public IActionResult DonutHoleCaching() 
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
