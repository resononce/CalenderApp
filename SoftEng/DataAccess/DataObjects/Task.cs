using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class Task
    {
        public int Id { get; set; }
        public TimeSpan EventTime { get; set; }
        public byte IsComplete { get; set; }
        [ForeignKey("Id")]
        public virtual Event Event{ get; set; }
    }
}
