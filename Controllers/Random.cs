using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RandomController
{
    public class RandomController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Counter") == null)
            {
                HttpContext.Session.SetInt32("Counter", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("Counter", ((int)HttpContext.Session.GetInt32("Counter")+1));
            }
            ViewBag.Counter = (int)HttpContext.Session.GetInt32("Counter");
            ViewBag.RandomStr = Passcode.CreateStr();
            return View("Index");
        }
    
    }
    public class Passcode
    {
        public static Random rand = new Random();
        public static string CreateStr()
        {
            string StrPasscode = "";
            int CreateChar;
            while (StrPasscode.Length < 14)
            {
                int num =rand.Next(1, 3);
                if(num == 1)
                {
                    CreateChar = rand.Next(48, 58);
                }
                else 
                {
                    CreateChar = rand.Next(65, 91);
                }
                char word = (char)CreateChar;
                StrPasscode+= word.ToString();
            }
            return StrPasscode;
        }
    }
}