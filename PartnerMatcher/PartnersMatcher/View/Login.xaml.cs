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
using PartnersMatcher.Controller;
using PartnersMatcher.Model;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private IController controller;
        public Login(IController controller)
        {
            InitializeComponent();
            tb_email.Focus();
            this.controller = controller;

        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            if (tb_email.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("קלט לא תקין");
            }
            else
            {
                User user = controller.login(tb_email.Text, passwordBox.Password);
                if (user == null)
                {
                    controller.showMessage("אימייל או סיסמא שגויים");
                }
                else
                {
                    DialogResult = true;
                    controller.showMessage("התחבר בהצלחה!");
                    ((MainWindow)Application.Current.MainWindow).notifyMe(user);
                }
                Close();
            }
        }
    }
}
