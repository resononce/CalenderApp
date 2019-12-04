using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftEng.DataAccess;
using SoftEng.DataAccess.DataObjects;
using SoftEng.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftEng.Controllers
{
    public class AdminController : Controller
    {
        private readonly Database db;
        public AdminController(team7Context context)
        {
            this.db = new Database(context);
        }

        // GET: /<controller>/
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ClassesTable()
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
            return View(model);
        }

        public bool AddClass()
        {
            return true;
        }

        public JsonResult EditClass(int id)
        {
            var class_ = db.GetClassById(id);
            var event_ = db.GetEventsByClassId(id);
            //Get a string[] of days of the week the class occurs
            string[] daysArray = class_.ClassDay.ToList().Select(i => i.Day.Day1).ToArray();

            //Convert timespan into time
            TimeSpan addTime = event_.EventTime.Add(class_.Time);
            String endTime = DateTime.Today.Add(addTime).ToString("HH:mm");
            TimeSpan subTime = addTime.Subtract(event_.EventTime);
            String classTotalTime = DateTime.Today.Add(subTime).ToString("HH:mm");
            return Json(new
            {
                className = class_.Name,
                classLocation = class_.Location,
                classStartDate = class_.StartDate.ToString("yyyy-MM-dd"),
                classEndDate = class_.EndDate.ToString("yyyy-MM-dd"),
                classDays = daysArray,
                classStartTime = DateTime.Today.Add(event_.EventTime).ToString("HH:mm"),
                classEndTime = endTime,
                classTime = classTotalTime
            });
        }

        public bool UpdateClass()
        {
            return true;
        }

        public bool DeleteClass()
        {
            return false;
        }
    }
}
