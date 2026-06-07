using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public abstract class User
    {
        // fields
        private string username, email, password;
        public List<Flight> bookedFlights = new List<Flight>();

        // properties
        public string Username { get { return username; } set { username = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }

        // constructors
        public User()
        {

        }
        public User(string username, string email, string password)
        {
			// Just sets the properties nothing interesting here.....
            Username = username;
            Email = email;
            Password = password;
        }
        // methods

        public void AddFlightToList(Flight flight)
        {
            Console.WriteLine("Adding flights....");
            bookedFlights.Add(flight);
        }

        public void GetBookedFlights()
        {
            foreach (Flight flight in bookedFlights)
            {
                flight.DisplayFlightDetails();
            }
        }
        public static void RR()
        {
            Console.Clear();                                                                                                                                             Console.WriteLine("Never gonna give you up\r\nNever gonna let you down\r\nNever gonna run around and desert you\r\nNever gonna make you cry\r\nNever gonna say goodbye\r\nNever gonna tell a lie and hurt you");
            Console.WriteLine();
            return;
        }
    }
}
