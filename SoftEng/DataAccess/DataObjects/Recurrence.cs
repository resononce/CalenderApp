using System;
using System.Collections.Generic;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class Recurrence
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Event Event { get; set; }
    }
}
