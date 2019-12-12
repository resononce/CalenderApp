using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks; // Was getting in the way of our Task Object
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
            var query = context.Users.Where(u => u.Username == username);
            User user = query.FirstOrDefault();
            return user;
        }

        public bool AddUser(User user)
        {
            var userExists = from x in context.Users
                             where x.Username == user.Username
                             select x;
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
            //var query = from class_ in context.Classes
            //            select class_;
            //IEnumerable<Class> classList = query.ToList();
            //return classList;
            var query = context.Classes.Include(c => c.ClassDay).ThenInclude(d => d.Day);
            return query;
        }

        internal object GetEventsByClassId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetUserEvents(User user)
        {
            //var query = context.Users.Include(e => e.Events)
            //                        .Where(e => e.Id == user.Id)
            //                        .FirstOrDefault();
            var query = context.Events.Where(e => e.UserId == user.Id).OrderBy(e => e.EventDate).ThenBy(e => e.EventTime);
            return query;
        }

        public IEnumerable<Event> GetUserEventsByDate(User user, DateTime startDate, DateTime endDate)
        {
            //var query = context.Users.Include(e => e.Events)
            //                        .Where(e => e.Id == user.Id)
            //                        .FirstOrDefault();
            var query = context.Events.Where(e => e.UserId == user.Id)
                                      .Where(e => e.EventDate >= startDate)
                                      .Where(e => e.EventDate <= endDate)
                                      .OrderBy(e => e.EventDate).ThenBy(e => e.EventTime);
            return query;
        }

        public IEnumerable<Event> GetUserEventsWithDetails(User user)
        {
            var query = context.Events.Where(e => e.UserId == user.Id).Include(e => e.Class).ThenInclude( c => c.ClassDay ).ThenInclude( d => d.Day)
                                                                      .Include(e => e.Recurrence)
                                                                      .Include(e => e.Task);
            return query;
        }

        public Task GetTaskById(int id)
        {
            var query = context.Tasks.Where(t => t.Id == id);
                return query.FirstOrDefault();
        }
        public Recurrence GetRecurrenceById(int id)
        {
            var query = context.Recurrences.Where(t => t.Id == id);
            return query.FirstOrDefault();
        }
        public Class GetClassById(int id)
        {
            var query = context.Classes.Include(c => c.ClassDay).ThenInclude(d => d.Day).Where(c => c.Id == id);
            return query.FirstOrDefault();
        }

        // Add Task
        public bool AddTask(Task task)
        {
            try
            {
                context.Tasks.Add(task);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add Event
        public bool AddEvent(Event evnt)
        {
            try
            {
                context.Events.Add(evnt);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add Recurrence
        public bool AddRecurrence(Recurrence recur)
        {
            try
            {
                context.Recurrences.Add(recur);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddClass(Class _class)
        {
            try
            {
                context.Classes.Add(_class);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateClass(int classId)
        {
            try
            {
                Class _class = GetClassById(classId);
                var query = context.Classes.Remove(_class);
                AddClass(_class);
                context.SaveChanges();
                return true;
            } catch(Exception e)
            {
                return false;
            }

        }

        public void DeleteClass(int classId)
        {
            Class _class = GetClassById(classId);
            var query = context.Classes.Remove(_class);
            context.SaveChanges();
        }

        // Get All Events Between 2 dates
        public IEnumerable<Event> GetEventsBetween(DateTime start, DateTime end, int userId)
        {
            var query = context.Events.Where( c => c.EventDate >= start)
                                       .Where( c => c.EventDate <= end)
                                       .Where( c => c.UserId == userId)
                                       .Where( c => c.ClassId == null)
                                       .Where( c => c.RecurrenceId == null);
            return query;
        }

        // Get All Events Between 2 dates
        public IEnumerable<Event> GetClassesBetween(DateTime start, DateTime end, int userId)
        {
            var query = context.Events.Include(c => c.Class)
                                        .Where(c => c.ClassId != null)
                                        .Where(c => c.UserId == userId)
                                        .Where(c => (c.Class.StartDate <= start && c.Class.EndDate >= start) ||
                                                    (c.Class.EndDate >= end && c.Class.StartDate <= end));
            return query;
        }

        // Get All Events Between 2 dates
        public IEnumerable<Event> GetRecurringEventsBetween(DateTime start, DateTime end, int userId)
        {
            var query = context.Events.Include(c => c.Recurrence)
                                        .Where(c => c.RecurrenceId != null)
                                        .Where(c => c.UserId == userId)
                                        .Where(c => c.ClassId == null)
                                        .Where(c => (c.Recurrence.StartDate <= start && c.Recurrence.EndDate >= start) ||
                                                    (c.Recurrence.EndDate >= end && c.Recurrence.StartDate <= end));
            return query;
        }

        // Get Events by classId
        public Event GetEventsByClassId(int classId)
        {
            var query = context.Events.Where(c => c.ClassId == classId);
            return query.FirstOrDefault();
        }
    }
}