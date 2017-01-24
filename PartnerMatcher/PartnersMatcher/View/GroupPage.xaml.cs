using PartnersMatcher.Controller;
using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Window
    {
        private IController controller;
        private Group group;
        private Admin admin;
        private bool isAdmin;

        public GroupPage(IController controller, Group group, User user)
        {
            InitializeComponent();
            Background = ((MainWindow)Application.Current.MainWindow).Background;
            this.controller = controller;
            this.group = group;           

            // check if the user is the admin of the group
            if(group.Admin == user.Email)
            {
                isAdmin = true;
                admin = new Admin(user);
            }
            else
            {
                isAdmin = false;
            }

            addUsersToMemeberList();
        }

        private void addUsersToMemeberList()
        {
            
        }
    }
}
