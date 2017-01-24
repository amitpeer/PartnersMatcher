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
        private int isSmoke;

        public int IsSmoke
        {
            get { return isSmoke; }
            set { isSmoke = value; }
        }
        private int isReligious;

        public int IsReligious
        {
            get { return isReligious; }
            set { isReligious = value; }
        }
        private int isAnimalLover;

        public int IsAnimalLover
        {
            get { return isAnimalLover; }
            set { isAnimalLover = value; }
        }




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
                if(controller.signUp(tb_email.Text, tb_firstName.Text, tb_lastName.Text, tb_city.Text, passwordBox.Password,IsSmoke,IsReligious,IsAnimalLover))
                    Close();
            }
        }
        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void smokeChanged(object sender, RoutedEventArgs e)
        {
            RadioButton checkedRadioButton = sender as RadioButton;
            //Smokeplus1 = false;
            //Smokeminus1.IsChecked = false;
            //Smoke0.IsChecked = false;
            //checkedRadioButton.IsChecked = true;
            if (checkedRadioButton.Name.Equals("Smokeplus1"))
            {
                IsSmoke = 1;
            }
            else if (checkedRadioButton.Name.Equals("Smokeminus1"))
            {
                IsSmoke = -1;
            }
            else
            {
                IsSmoke = 0;
            }
        }

        private void ReligiousChanged(object sender, RoutedEventArgs e)
        {
            RadioButton checkedRadioButton = sender as RadioButton;
            //Religiousplus1.IsChecked = false;
            //Religiousminus1.IsChecked = false;
            //Religious0.IsChecked = false;
            //checkedRadioButton.IsChecked = true;
            if (checkedRadioButton.Name.Equals("Religiousplus1"))
            {
                IsReligious = 1;
            }
            else if (checkedRadioButton.Name.Equals("Religiousminus1"))
            {
                IsReligious = -1;
            }
            else
            {
                IsReligious = 0;
            }
        }

        private void AnimalChanged(object sender, RoutedEventArgs e)
        {
            RadioButton checkedRadioButton = sender as RadioButton;
            //Animalsplus1.IsChecked = false;
            //Animalsminus1.IsChecked = false;
            //Animals0.IsChecked = false;
            //checkedRadioButton.IsChecked = true;
            if (checkedRadioButton.Name.Equals("Animalsplus1"))
            {
                IsAnimalLover = 1;
            }
            else if (checkedRadioButton.Name.Equals("Animalsminus1"))
            {
                IsAnimalLover = -1;
            }
            else
            {
                IsAnimalLover = 0;
            }
        }
    }
}