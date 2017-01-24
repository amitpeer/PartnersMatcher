using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PartnersMatcher.Controller;

namespace PartnersMatcher.Model
{
    class PMModel: IModel
    {
        private IController controller;
        private DatabaseUtils databaseUtils;
        private User _correntLoggedInUser;

        public PMModel()
        {
            databaseUtils = new DatabaseUtils();
            
        }

        public User login(string email, string pass)
        {
            User user = null;
            try
            {
            user = databaseUtils.connectUser(email, pass);
            }
            catch (Exception e)
            {
                controller.showMessage("לא הצלחנו להתחבר למסד הנתונים.\n" + e.Message);
            }
            _correntLoggedInUser = user;
            return user;
        }

        public void setController(IController controller)
        {
            this.controller = controller;
        }

        public bool signUp(string email, string firstName, string lastName, string city, string password)
        {
            bool isSignUp = false;
            try
            {
                User user = new User(email, firstName, lastName, city, password);
                databaseUtils.addUser(user);
                sentValidationEmail(user);
                controller.showMessage("ההרשמה עברה בהצלחה והודעה לאימייל נשלחה.");
                isSignUp = true;

            }
            catch (Exception e)
            {
                controller.showMessage(e.Message);
            }
            return isSignUp;
        }

        private void sentValidationEmail(User user)
        {
            MailMessage mail = new MailMessage("partnersystemconf@gmail.com", user.Email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("partnersystemconf@gmail.com", "partnermatcher");
            client.EnableSsl = true;
            mail.Subject = "!ברוך הבא למשפחת פרטנר מאטצ'ר";
            mail.Body = "שלום " + user.FirstName + "\n" +
                        "\nאנו שמחים שבחרת להצטרף אלינו ומאחלים לך שימוש מהנה באפליקציה"
                        + ".לכל בעיה ניתן לפנות אלינו דרך שירות הלקוחות של יד2";
            client.Send(mail);
        }

        public List<Ad> getAdsByLocationAndCategory(string location, string category)
        {
            List<Ad> adList = null;
            try
            {
                adList = databaseUtils.getAdsByLocationAndCategory(location, category);
            }
            catch (Exception e)
            {
                controller.showMessage(e.Message);
            }
            return adList;
        }

        public void createNewGroup(string category, string location, string title, string adContent, string groupContent)
        {
            databaseUtils.createNewGrop(category, location, title, adContent, groupContent, _correntLoggedInUser.Email);
        }

        public Group getGroupById(int id)
        {
            return databaseUtils.getGroupByID(id);
        }

        public User getUserByEmail(string email)
        {
            return databaseUtils.getUserByEmail(email);
        }
    }
}
