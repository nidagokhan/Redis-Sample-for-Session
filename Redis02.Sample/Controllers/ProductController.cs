using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis02.Sample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public ProductController(IDistributedCache distributedCache)
        {
            _distributedCache= distributedCache;
        }
        public IActionResult CacheSetString()
        {
            _distributedCache.SetString("date", DateTime.Now.ToString(),new DistributedCacheEntryOptions 
            {
                AbsoluteExpiration= DateTime.Now.AddSeconds(200),
                SlidingExpiration=TimeSpan.FromSeconds(60)
            });
            return View();
        }
        public IActionResult CacheGetString()
        {
            string value=_distributedCache.GetString("date");
            return View();
        }
        public IActionResult CacheRemove()
        {
            _distributedCache.Remove("date");
            return View();
        }
    }
}
