using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_WSA.business_objects
{
    public class User
    {
        public User(string userName, string pass)
        {
            UserName = userName;
            UserPassword = pass;
        }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
