using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisSession.Sample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisSession.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //docker run --rm -p 80:6379 --name redisproject -d redis
        [HttpPost]
        public IActionResult Index(string UserName, string UserID)
        {
            //username ve userıd byte çevrilip sessiona atandığında, session yerine rediste saklanır
            if (!string.IsNullOrEmpty(UserName))
            {
                var bytes = Encoding.UTF8.GetBytes(UserName);
                HttpContext.Session.Set("UserName", bytes);
            }

            if (!string.IsNullOrEmpty(UserID))
            {
                var bytes2 = Encoding.UTF8.GetBytes(UserID);
                HttpContext.Session.Set("UserID", bytes2);
            }

            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            //sessiondan yani redisten çekilen data bytedan string context çevrilir  çekilen data viewdata ile viewde gösterilir   
            var bytes = default(byte[]);
            HttpContext.Session.TryGetValue("UserName", out bytes);
            var content = Encoding.UTF8.GetString(bytes);

            var bytes2 = default(byte[]);
            HttpContext.Session.TryGetValue("UserID", out bytes2);
            var content2 = Encoding.UTF8.GetString(bytes2);

            ViewData["Message"] = content + " User ID:" + content2;

            return View();
        }
    }
}
