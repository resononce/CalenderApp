using System;
using System.Collections.Generic;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class CompareRequest
    {
        public int Id { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public byte? Accepted { get; set; }
    }
}
