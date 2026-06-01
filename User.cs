using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public abstract class User
    {
        // fields
        private string username, email, password;
        private List<Flight> bookedFlights = new List<Flight>();

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
    }
}
