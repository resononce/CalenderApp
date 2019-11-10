using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftEng.DataAccess;
using SoftEng.DataAccess.DataObjects;
using SoftEng.Models;

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
                //model.UserHomeEvents.Add(new Event { Id = 1, EventDate = new DateTime(), EventTime = new TimeSpan(), Name = "Test", Location = "Test Place" });
                model.UserHomeEvents = this.db.GetUserEvents(HomeController.user).ToList();
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
            var classList = db.GetAllClasses().
                Select(class_ => new Class
                {
                    Id = class_.Id,
                    Name = class_.Name,
                    Location = class_.Location,
                    StartDate = class_.StartDate,
                    EndDate = class_.EndDate,
                    Time = class_.Time
                });

            List<Class> model = classList.ToList();

            return View(model);
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public ActionResult RequestWeekly(DateTime start, DateTime end)
        {
            db.GetEventsBetween(start, end);
            //TO DO
            return Json(new
            {
                status = false,
                message = "Task failed successfully!"
            });
        }

        public DateTime ISODatetoDateTime(string date)
        {
            DateTime dt = DateTime.ParseExact(date,
                      "ddd MMM d HH:mm:ss UTCzzzzz yyyy",
                      CultureInfo.InvariantCulture);
            return dt;
        }

        //Not fully working yet
        public ActionResult AddNewTask(string taskName, string startTimeStr,
            string endTimeStr, string taskDateStr, bool recurring,
            Dictionary<string, bool> daysRecurring, string recurringEndDateStr)
        {
            DateTime startTime = ISODatetoDateTime(startTimeStr);
            DateTime endTime = ISODatetoDateTime(endTimeStr);
            DateTime taskDate = ISODatetoDateTime(startTimeStr);
            DateTime recurringEndDate = ISODatetoDateTime(recurringEndDateStr);
            Event evnt = new Event
            {
                Name = taskName,
                //UserId = HomeController.user.Id,
                EventDate = startTime,
                EventTime = endTime - startTime,
                Task = new Task
                {
                    IsComplete = 0
                }
            };
            if(recurring)
            {
                evnt.Recurrence = new Recurrence
                {
                    StartDate = startTime,
                    EndDate = recurringEndDate
                };
            }
            bool success = db.AddEvent(evnt);
            return Json(new
            {
                status = success,
                message = "Nope"
            });
        }
    }
}
