﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServerBank.db.entities
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
