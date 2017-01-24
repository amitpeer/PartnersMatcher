using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public class Ad
    {

        private int _serialNumber;
        private string _category;
        private string _location;
        private string _admin;
        private string _title;

        public int SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }

        public Ad() { }

        public Ad(int serialNumber, string category, string location, string title)
        {
            _serialNumber = serialNumber;
            _category = category;
            _location = location;

            _title = title;
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        public string Title { get { return _title; } set { _title = value; } }

        public override string ToString()
        {
            string tostring = _serialNumber.ToString() + " " + _category.ToString() + " " + _admin.ToString() + " " + _title;
            return tostring;
        }
        
    }
}
