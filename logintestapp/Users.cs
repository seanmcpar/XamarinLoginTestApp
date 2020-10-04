using System;
using System.Collections.Generic;
using System.Text;

namespace logintestapp
{
    public class Users
    {
        public int id { get; set; }
        public string passwordHash { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
    }
}
