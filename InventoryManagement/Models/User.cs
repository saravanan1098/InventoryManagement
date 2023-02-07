using System;

namespace InventoryManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Desgination { get; set; }
        public string Division { get; set; }
        public string Deport { get; set; }
        public string Role { get; set; } = "User";

    }
}
