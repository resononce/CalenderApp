﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftEng.DataAccess.DataObjects;

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
            var query = from x in context.Users
                        where x.Username == username
                        select x;
            User user = query.FirstOrDefault();
            return user;
        }

        public bool AddUser(User user)
        {
            var userExists = from x in context.Users where x.Username == user.Username select x;
            if (userExists.Count() != 0)
            {
                return false;
            }
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        // Get All Classes
        public IEnumerable<Class> GetAllClasses()
        {
            var query = from class_ in context.Classes
                        select class_;
            IEnumerable<Class> classList = query.ToList();
            return classList;
        }

        public IEnumerable<Event> GetUserEvents(User user)
        {
            var query = context.Users.Include(e => e.Events)
                                    .Where(e => e.Username == user.Username)
                                    .FirstOrDefault();
            return query.Events;
        }

        //TODO
        // Add Task
        public bool AddTask(Event task)
        {
            try 
            { 
                context.Events.Add(task);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //TODO
        // Get All Events Between 2 dates
        public IEnumerable<Class> GetEventsBetween(DateTime start, DateTime end)
        {
            //Change this stuff
            var query = context.Classes.Where( c => c.StartDate >= start)
                                       .Where( c => c.EndDate <= end);
            return query;
        }
    }
}
