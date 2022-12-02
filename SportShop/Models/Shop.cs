﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportShop.Models;

namespace SportShop.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
