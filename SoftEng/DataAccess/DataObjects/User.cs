﻿using System;
using System.Collections.Generic;

namespace SoftEng.DataAccess.DataObjects
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte IsAdmin { get; set; }
        public string Phash { get; set; }
    }
}