using Microsoft.AspNetCore.Mvc;
using Redis02.Sample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redis02.Sample.Controllers
{
    public class RedisController : Controller
    {
        private readonly RedisService _redisService;
        public RedisController(RedisService redisService)
        {
            _redisService= redisService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
