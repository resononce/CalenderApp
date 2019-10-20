using System;
using System.Collections.Generic;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class ClassDay
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public int ClassId { get; set; }
    }
}
