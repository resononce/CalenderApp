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
            if (HomeController.user != null && HomeController.user.IsAdmin == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult ClassesTable()
        {
            if (HomeController.user != null && HomeController.user.IsAdmin == 1)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public JsonResult EditClass(int id)
        {
            var class_ = db.GetClassById(id);
            return Json(new
            {
                className = class_.Name,
                classLocation = class_.Location,
                classStartDate = class_.StartDate.ToString("yyyy-MM-dd"),
                classEndDate = class_.EndDate.ToString("yyyy-MM-dd"),
                classTime = class_.Time.ToString()
            });
        }
    }
}
