﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.IdentityModel
{
    public class CreateAccountDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Role { get; set; }
        public string Image { get; set; }
    }
}
