using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesignACachingStrategy.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace DesignACachingStrategy.Controllers
{
    public class HomeController : Controller
    {
        readonly IDistributedCache _cache; 

        public HomeController(IDistributedCache cache) 
        {
            _cache = cache;
        }

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

        public async Task<IActionResult> AzureRedisCache() 
        {
            string stringValue;
            var uniqueValue = await _cache.GetAsync("TestUniqueValue");
            
            if (uniqueValue == null) {
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                var newGuid = Guid.NewGuid();
                stringValue = newGuid.ToString();

                await _cache.SetAsync("TestUniqueValue", newGuid.ToByteArray(), options);
            }
            else {
                stringValue = new Guid(uniqueValue).ToString();
            }

            return View(stringValue);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
