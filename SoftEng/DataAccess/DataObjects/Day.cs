using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class Day
    {
        public int Id { get; set; }
        public string Day1 { get; set; }
        [ForeignKey("DayOfWeek")]
        public virtual ICollection<ClassDay> ClassDay { get; set; }
    }
}
