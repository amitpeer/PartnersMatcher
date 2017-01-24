using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public class User
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }



        private string _password;

        public string Pssword
        {
            get { return _password; }
            set { _password = value; }
        }


        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private List<int> _groups;

        public List<int> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        public User(string email, string firstName, string lastName, string city, string password)
        {
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _city = city;
            _groups = new List<int>();
        }

        public User() { }
    }
}
