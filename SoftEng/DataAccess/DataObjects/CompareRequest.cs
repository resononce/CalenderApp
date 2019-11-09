using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class CompareRequest
    {
        public int Id { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public byte? Accepted { get; set; }
        [ForeignKey("FromUser")]
        public virtual User FromUserTable{ get; set; }
        [ForeignKey("ToUser")]
        public virtual User ToUserTable{ get; set; }
    }
}
