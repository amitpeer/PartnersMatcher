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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        static readonly string localPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private static readonly string pathToDb = localPath + @"\PartnerMatcherDB.accdb";
        public Signup()
        {
            InitializeComponent();
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            if (tb_firstName.Text == "" || tb_lastName.Text == "" || tb_email.Text == "" || tb_city.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("Bad input");
            }
            else
            {
                User user = new User(tb_email.Text, tb_firstName.Text, tb_lastName.Text, tb_city.Text, passwordBox.Password);
                DatabaseUtils databaseUtils = new DatabaseUtils(pathToDb);
                try
                {
                    databaseUtils.addUser(user);
                    MessageBox.Show("Success. Please expect confirimation email");
                    Close();
                }
                catch (Exception expection)
                {
                    MessageBox.Show("Signin failed." + "\n" + expection.ToString());
                }
            }
        }
    }
}
