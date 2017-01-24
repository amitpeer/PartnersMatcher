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
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        User user;
        IController controller;

        public UserProfile(User user, IController controller)
        {
            InitializeComponent();
            Background = ((MainWindow)Application.Current.MainWindow).Background;
            this.user = user;
            this.controller = controller;

            label_firstName.Content = user.FirstName;
            label_lastName.Content = user.LastName;
            label_email.Content = user.Email;
            label_city.Content = user.City;
            //check if user smokes
            if (user.Smoke == 1)
                label_smoking.Content = "כן";
            else if (user.Smoke == -1)
                label_smoking.Content = "לא";
            else
                label_smoking.Content = "לא משנה לי";
            
            //check if user religious
            if (user.Religious == 1)
                label_religious.Content = "כן";
            else if (user.Religious == -1)
                label_religious.Content = "לא";
            else
                label_religious.Content = "לא משנה לי";

            //check if user likes animal
            if (user.AnimalLover == 1)
                label_animalLover.Content = "כן";
            else if (user.AnimalLover == -1)
                label_animalLover.Content = "לא";
            else
                label_animalLover.Content = "לא משנה לי";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
