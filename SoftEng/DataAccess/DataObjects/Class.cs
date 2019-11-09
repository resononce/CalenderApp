using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Id")]
        public virtual ICollection<ClassDay> ClassDay{ get; set; }
    }
}
