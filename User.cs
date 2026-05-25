using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public class User
    {
        // fields
        private string username, email, password, userType;


        // properties
        public string Username { get { return username; } set { username = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string UserType { get { return userType; } set { userType = value; } }


        // constructors
        public User()
        {

        }
        public User(string username, string email, string password, string userType)
        {
            Username = username;
            Email = email;
            Password = password;
            UserType = userType;
        }
        // methods
        
    }
}
