using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte IsAdmin { get; set; }
        public string Phash { get; set; }
        [ForeignKey("Id")]
        public virtual ICollection<Event> Events{get; set;}
        [ForeignKey("Id")]
        public virtual ICollection<CompareRequest> CompareRequests{get; set;}
    }
}
