using System;
using System.Collections.Generic;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public int? ClassId { get; set; }
        public int? RecurrenceId { get; set; }
        public int? TaskId { get; set; }
    }
}
