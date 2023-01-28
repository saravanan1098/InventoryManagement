﻿namespace InventoryManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Desgination { get; set; }
        public string Department { get; set; }
        public string Role { get; set; } = "User";

    }
}