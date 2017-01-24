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
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _city;
        private List<int> _groups;
        private int _smoke;
        private int _religious;
        private int _animalLover;
        public User() { }

        public User(string email, string firstName, string lastName, string city, string password, int smokes, int religious, int animalLover)
        {
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _city = city;
            _groups = new List<int>();
        }

        public User(User other)
        {
            _email = other.Email;
            _firstName = other.FirstName;
            _lastName = other.LastName;
            _password = other._password;
            _city = other.City;
            _groups = other.Groups;
            _animalLover = other.AnimalLover;
            _religious = other._religious;
            _smoke = other.Smoke;
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Pssword
        {
            get { return _password; }
            set { _password = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public List<int> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }
        public int AnimalLover
        {
            get { return _animalLover; }
            set { _animalLover = value; }
        }
        public int Religious
        {
            get { return _religious; }
            set { _religious = value; }
        }
        public int Smoke
        {
            get { return _smoke; }
            set { _smoke = value; }
        }
        public override string ToString()
        {
            return FirstName + " " + LastName + ", " + City + ", " + Email;
        }

    }
}
