using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnersMatcher.Controller;

namespace PartnersMatcher.Model
{
    interface IModel
    {
        void setController(IController controller);
        void signUp(string email, string firstName, string lastName, string city, string password);
        User login(string email, string pass);

        List<Ad> getAdsByLocationAndCategory(string location, string category);
    }
}
