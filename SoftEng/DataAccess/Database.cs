using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftEng.DataAccess.DataObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftEng.DataAccess
{
    public class Database
    {
        private readonly team7Context context;
        public Database(team7Context context)
        {
            this.context = context;
        }
        /// <summary>
        /// Gets a Username/Password Combo using the username
        /// </summary>
        /// <param name="username">The suername being added</param>
        /// <returns>a User Object</returns>
        public User GetUserByName(string username)
        {
            var query = from x in context.Users where x.Username == username select x;
            User user = query.FirstOrDefault();
            return user;
        }

        public bool AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        // Get All Classes
        public IEnumerable<Class> GetAllClasses()
        {
            var query = from class_ in context.Classes select class_;
            IEnumerable<Class> classList = query.ToList();
            return classList;
        }

        //TO DO
        // Add Task
        public bool AddTask(Event task)//IDK
        {
            return false;
        }

        //TO DO
        // Get All Events Between 2 dates
        public IEnumerable<Class> GetEventsBetween(DateTime start, DateTime end)
        {
            //Change this stuff
            var query = from class_ in context.Classes select class_;
            IEnumerable<Class> classList = query.ToList();
            return classList;
        }
    }
}
