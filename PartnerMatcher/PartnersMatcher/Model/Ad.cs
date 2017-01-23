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

        public int SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }


        private string _category;

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }


        private string _location;

        public string Lcation
        {
            get { return _location; }
            set { _location = value; }
        }


        private string _admin;

        public string Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }



        public Ad(int serialNumber, string category, string location, string admin)
        {
            _serialNumber = serialNumber;
            _category = category;
            _location = location;
            _admin = admin;
        }

        public override string ToString()
        {
            string  tostring=_serialNumber.ToString() +" "+ _category.ToString()+" " + _admin.ToString();
            return tostring;
        }

        public Ad() { }
    }
}
