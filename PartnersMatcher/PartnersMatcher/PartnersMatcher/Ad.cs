using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class Ad
    {
        private int _serialNumber;
        private string _category;
        private string _location;
        private string _admin;

        public Ad(int serialNumber, string category, string location, string admin)
        {
            _serialNumber = serialNumber;
            _category = category;
            _location = location;
            _admin = admin;
        }

        public Ad() { }
    }
}
