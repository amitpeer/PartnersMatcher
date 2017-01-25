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
            if (listView_requests.Items.Count == 0)
            {
                listView_requests.Visibility = Visibility.Hidden;
                label_noRequests.Visibility = Visibility.Visible;
            }
        }

        private void addUsersToMemeberList()
        {
            foreach(string email in group.Users)
            {
                listView_members.Items.Add(controller.getUserByEmail(email).ToString());
            }
        }

        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void listView_requests_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                string selectedUserEmail = group.Requests[listView_requests.SelectedIndex].User;

                MessageBoxResult result = MessageBox.Show("?האם ברצונך לאשר משתמש זה לקבוצה", "אישור", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                else if (result == MessageBoxResult.Yes)
                {
                    controller.acceptUserToGroup(selectedUserEmail, group.Id);

                    //add user to members ListView
                    listView_members.Items.Add(controller.getUserByEmail(selectedUserEmail));

                    // add user to the Group users object
                    group.Users.Add(selectedUserEmail);
                                  
                }
                else if (result == MessageBoxResult.No)
                {
                    controller.declineUserToGroup(selectedUserEmail, group.Id);
                }

                //remove user from requests ListView
                listView_requests.Items.RemoveAt(listView_requests.SelectedIndex);
        }

        private void listView_members_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (listView_members.SelectedIndex == -1)
                listView_members.SelectedIndex = 1;
            string selectedUserEmail = group.Users[listView_members.SelectedIndex];
            UserProfile userProfile = new UserProfile(controller.getUserByEmail(selectedUserEmail), controller);
            userProfile.ShowDialog();
        }

        private void listView_requests_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (listView_requests.SelectedIndex == -1)
                listView_requests.SelectedIndex = 1;
            string selectedUserEmail = group.Requests[listView_requests.SelectedIndex].User;
            UserProfile userProfile = new UserProfile(controller.getUserByEmail(selectedUserEmail), controller);
            userProfile.ShowDialog();
        }
    }
}
