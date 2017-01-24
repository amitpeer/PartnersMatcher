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
        private const int ADMIN_WIDTH = 740;
        private const int REGULAR_WIDTH = 402;

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
                Width = ADMIN_WIDTH;
                label_groupTitleForAdmin.Content = group.Title;
                addUsersToRequestsList();
            }
            else
            {
                isAdmin = false;
                Width = REGULAR_WIDTH;
                label_groupTitle.Content = group.Title;
            }

            // fill in the labels with the group details
            label_content.Content = group.Content;
            addUsersToMemeberList();
        }

        private void addUsersToRequestsList()
        {
            foreach(Request request in group.Requests)
            {
                listView_requests.Items.Add(controller.getUserByEmail(request.User).ToString());
            }
        }

        private void addUsersToMemeberList()
        {
            foreach(string email in group.Users)
            {
                listView_members.Items.Add(controller.getUserByEmail(email).ToString());
            }
        }

        private void listView_requests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedUserEmail = group.Requests[listView_requests.SelectedIndex].User;

            MessageBoxResult result = MessageBox.Show("?האם ברצונך לאשר משתמש זה לקבוצה", "אישור", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                controller.acceptUserToGroup(selectedUserEmail, group.Id);
            }
            else
            {
                controller.declineUserToGroup(selectedUserEmail, group.Id);
            }

        }

        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
