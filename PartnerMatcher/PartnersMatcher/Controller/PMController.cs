using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnersMatcher.Model;
using PartnersMatcher.View;

namespace PartnersMatcher.Controller
{
    class PMController:IController
    {
        private IView view;
        private IModel model;
        public PMController(IView view,IModel model)
        {
            this.view = view;
            this.model = model;
        }

        public bool signUp(string email, string firstName, string lastName, string city, string password)
        {
            return model.signUp(email,firstName,lastName,city,password);
        }

        public void showMessage(string text)
        {
            view.showMessage(text);
        }

        public User login(string email, string pass)
        {
            return model.login(email, pass);
        }

        public List<Ad> getAdsByLocationAndCategory(string location, string category)
        {

            return model.getAdsByLocationAndCategory(location, category);
        }

        public void createNewGroup(string category, string location, string title, string adContent, string groupContent)
        {
            model.createNewGroup(category, location, title, adContent, groupContent);
        }

        public Group getGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public User getUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
