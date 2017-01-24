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

        bool signUp(string email, string firstName, string lastName, string city, string password);

        User login(string email, string pass);

        List<Ad> getAdsByLocationAndCategory(string location, string category);

        void createNewGroup(string category, string location, string title, string adContent,string groupContent);

        Group getGroupById(int id);
        User getUserByEmail(string email);
    }
}
