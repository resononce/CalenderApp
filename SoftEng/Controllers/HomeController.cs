using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftEng.DataAccess;
using SoftEng.DataAccess.DataObjects;
using SoftEng.Models;
using System.Security.Cryptography;
using System.Text;

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
                SHA256 crypt = SHA256.Create();
                password = Encoding.ASCII.GetString(crypt.ComputeHash(Encoding.ASCII.GetBytes(password)));
                crypt.Dispose();
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
                SHA256 crypt = SHA256.Create();
                byte[] hash = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
                string phash = Encoding.ASCII.GetString(hash);
                crypt.Dispose();
                user = new User {
                    IsAdmin = 0,
                    Username = username,
                    Phash = phash
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
