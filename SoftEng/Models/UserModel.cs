using System;
namespace SoftEng.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte IsAdmin { get; set; }
        public string Phash { get; set; }
    }
}
