using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class User
    {
        private string _email;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _city;

        public User(string email, string firstName, string lastName, string password, string city)
        {
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _city = city;
        }

        public User() { }
    }
}
