using PartnersMatcher.Controller;
using PartnersMatcher.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {        
        IController controller;
        public Signup(IController controller)
        {
            InitializeComponent();
            tb_email.Focus();
            this.controller = controller;
        }
        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            if (tb_firstName.Text == "" || tb_lastName.Text == "" || tb_email.Text == "" || tb_city.Text == "" || passwordBox.Password == "")
            {
                MessageBox.Show("קלט לא תקין");
            }
            else
            {                
                controller.signUp(tb_email.Text, tb_firstName.Text, tb_lastName.Text, tb_city.Text, passwordBox.Password);
                Close();
            }
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}