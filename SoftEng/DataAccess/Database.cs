﻿using System;
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
            if (context.Users.Contains(user))
            {
                return false;
            }
            else
            {
                context.Users.Add(user);
                return true;
            }
        }
    }
}
