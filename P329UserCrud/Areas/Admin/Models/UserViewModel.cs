﻿namespace P329UserCrud.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public List<string> Roles { get; set; }
    }
}
