﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject.Dtos
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public IList<string> Roles { get; set; }
        public string Token { get; set; }
        public byte[]? Image { get; set; }

    }
}
