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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private static readonly string pathToDb = "";
        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DatabaseUtils databaseUtils = new DatabaseUtils(pathToDb);
                if (tb_email.Text == "" || passwordBox.Password == "")
                {
                    MessageBox.Show("Bad input");
                }
                else
                {
                    User user = databaseUtils.connectUser(tb_email.Text, passwordBox.Password);
                    if (user == null)
                    {
                        MessageBox.Show("Email or password are wrong");
                    }
                    else
                    {
                        MessageBox.Show("Login successfully");
                        Close();
                    }
                }
            }
            catch (Exception excepction)
            {
                MessageBox.Show("Could not connect to DB\n" + excepction.ToString());
            }
        }
    }
}
