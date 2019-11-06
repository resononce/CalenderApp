using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftEng.Models;
using SoftEng.DataAccess;
using SoftEng.DataAccess.DataObjects;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftEng.Controllers
{
    public class UserController : Controller
    {
        private readonly Database db;

        public UserController(team7Context context)
        {
            this.db = new Database(context);
        }
        // GET: /<controller>/
        public IActionResult Home()
        {
            if (HomeController.user != null && HomeController.user.IsAdmin == 0)
            {
                UserHomeModel model = new UserHomeModel();
                model.UserHomeEvents = new List<Event>();
                model.UserHomeEvents.Add(new Event { Id = 1, EventDate = new DateTime(), EventTime = new TimeSpan(), Name = "Test", Location = "Test Place" });
                //model.UserHomeEvents = this.db.GetUserEvents();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
