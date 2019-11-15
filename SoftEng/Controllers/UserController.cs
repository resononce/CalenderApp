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
using Newtonsoft.Json;

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

            ClassListModel model = new ClassListModel
            {
                ClassList = classList
            };

            //TODO pass in list of classes
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
        
        public ActionResult AddNewTask(string taskName, string startTimeStr,
            string endTimeStr, string taskDateStr, bool recurring,
            Dictionary<int, bool> daysRecurring, string recurringEndDateStr)
        {
            bool success = false;
            TimeSpan time = TimeSpan.Parse(endTimeStr) - TimeSpan.Parse(startTimeStr);
            DateTime taskDate = DateTime.Parse(taskDateStr);
            
            Event evnt = new Event
            {
                Name = taskName,
                UserId = HomeController.user.Id,
                Location = "",
                EventDate = taskDate,
                EventTime = time,
                Task = new Task
                {
                    IsComplete = 0
                }
            };
            if(recurring)
            {
                DateTime recurEndDate = DateTime.Parse(recurringEndDateStr);
                evnt.Recurrence = new Recurrence
                {
                    StartDate = taskDate,
                    EndDate = recurEndDate
                };
                Event e = Clone<Event>(evnt);
                success = db.AddEvent(e);
                if(success)
                {
                    for (DateTime d = taskDate; d <= recurEndDate; d = d.AddDays(1))
                    {
                        if (daysRecurring[(int)d.DayOfWeek])
                        {
                            e = Clone<Event>(evnt);
                            e.EventDate = d;
                            db.AddEvent(e);
                        }
                    }
                }
            }
            else
                success = db.AddEvent(evnt);

            return Json(new
            {
                status = success,
                message = "name: " + evnt.Name +
                          "\n user id: " + evnt.UserId +
                          "\n location: " + evnt.Location +
                          "\n event date: " + evnt.EventDate +
                          "\n event time: " + evnt.EventTime +
                          "\n recurrence: " + recurring
            });
        }

        public static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

    }
}
