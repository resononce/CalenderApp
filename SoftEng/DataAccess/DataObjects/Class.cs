using System;
using System.Collections.Generic;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Time { get; set; }
    }
}
