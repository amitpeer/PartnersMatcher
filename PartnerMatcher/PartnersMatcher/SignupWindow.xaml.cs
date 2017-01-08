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

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for SignupWindow.xaml
    /// </summary>
    public partial class SignupWindow : Window
    {
        public SignupWindow()
        {
            InitializeComponent();
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {

            if (tb_firstName.Text == null || tb_lastName.Text == null || tb_email.Text == null || tb_city.Text == null || passwordBox.Password == null)
            {
                MessageBox.Show("Bad input");
            }
            else
            {
                User user = new User(tb_email.Text, tb_firstName.Text, tb_firstName.Text, passwordBox.Password, tb_lastName.Text);
                DatabaseUtils databaseUtils = new DatabaseUtils(pathToDb);
                try
                {
                    databaseUtils.addUser(user);
                }
                catch (Exception expection)
                {
                    MessageBox.Show("Signin failed.");
                }
            }
        }
    }
}
