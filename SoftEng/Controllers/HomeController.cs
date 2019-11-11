using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftEng.DataAccess;
using SoftEng.DataAccess.DataObjects;
using SoftEng.Models;

namespace SoftEng.Controllers
{
    public class HomeController : Controller
    {
        public static User user = null;
        private readonly Database db;
        public HomeController(team7Context context)
        {
            this.db = new Database(context);
        }

        [HttpGet]
        public async Task<ActionResult> _NavBarPartial()
        {
            //class Wrapper { public UserModel um { get; set; } }
            
            ViewBag.User = user;
            return PartialView("_NavBarPartial", user);
        }

        public ActionResult Validate(string username, string password)
        {
            var _user = db.GetUserByName(username);
            if (_user != null)
            {
                if (_user.Phash == password)
                {
                    HomeController.user = _user;
                    ViewBag.User = _user;
                    return Json(new {
                        status = true,
                        message = "Login Successfull!",
                        isAdmin = _user.IsAdmin == 0 ? false : true
                    });
                }
                else
                {
                    return Json(new {
                        status = false,
                        message = "Invalid Password!"
                    });
                }
            }
            else
            {
                return Json(new {
                    status = false,
                    message = "Invalid Username!"
                });
            }
        }

        public ActionResult Register(string username, string password)
        {
            User user = db.GetUserByName(username);
            if(user != null)
            {
                return Json(new {
                    status = false,
                    message = "User already exists"
                });
            }
            else
            {
                user = new User {
                    IsAdmin = 0,
                    Username = username,
                    Phash = password
                };
                bool isSuccessful = db.AddUser(user);
                return Json(new {
                    status = isSuccessful,
                    message = "There was a problem registering"
                });
            }
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Index()
        {
            user = null;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0, 
            Location = ResponseCacheLocation.None, 
            NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
