﻿using System;
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

        public JsonResult AddNewClass(string name, int id, string location, string startDateStr, 
                            string endDateStr, Dictionary<int, bool> days,
                            string startTime, string endTime)
        {
            List<ClassDay> classDays = new List<ClassDay>();
            foreach (KeyValuePair<int, bool> entry in days)
            {
                if (entry.Value)
                    classDays.Add(new ClassDay
                    {
                        DayOfWeek = entry.Key
                    });
            }
            Class _class = new Class
            {
                Name = name,
                Location = location,
                StartDate = DateTime.Parse(startDateStr),
                EndDate = DateTime.Parse(endDateStr),
                ClassDay = classDays,
                Time = TimeSpan.Parse(endTime) - TimeSpan.Parse(startTime),
            };
            bool success = db.AddClass(_class);
            return Json(new
            {
                status = success,
                message = "name: " + name +
              "\n location: " + location +
              "\n class date: " + _class.StartDate +
              "\n class time: " + _class.StartDate
            });
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

        public JsonResult UpdateClass(string name, int id, string location, string startDateStr,
                            string endDateStr, Dictionary<int, bool> days,
                            string startTime, string endTime)
        {
            DeleteClass(id);
            return AddNewClass(name, id, location, startDateStr, endDateStr, 
                                days, startTime, endTime);
        }

        public bool DeleteClass(int id)
        {
            db.DeleteClass(id);
            return true;
        }
    }
}
