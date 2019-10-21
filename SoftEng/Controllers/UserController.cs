using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftEng.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult WeeklyView()
        {
            return View();
        }

        public IActionResult CompareSchedules()
        {
            return View();
        }

        public IActionResult Enroll()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }
    }
}
