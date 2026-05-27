using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public class Admin : User
    {
        // fields



        // properties



        // constructors
        public Admin()
        {

        }
        public Admin(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
        // methods



    }
}
