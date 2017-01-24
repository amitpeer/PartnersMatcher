using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PartnersMatcher.Model;

namespace PartnersMatcher.Controller
{
    public interface IController
    {
        bool signUp(string email, string firstName, string lastName, string city, string password);

        void showMessage(string text);

        User login(string email, string pass);

        List<Ad> getAdsByLocationAndCategory(string location, string category);

        void createNewGroup(string category, string location, string title, string adContent, string groupContent);

        Group getGroupById(int id);

        User getUserByEmail(string email);
    }
}
