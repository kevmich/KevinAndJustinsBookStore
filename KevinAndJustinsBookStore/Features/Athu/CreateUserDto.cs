﻿using System.ComponentModel.DataAnnotations;

namespace KevinAndJustinsBookStore.Features.Authentication
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public string Email { get; set; }
    }
}