using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class ClassDay
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class{ get; set; }
        [ForeignKey("DayOfWeek")]
        public virtual Day Day{get; set;}
    }
}
