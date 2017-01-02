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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartnersMatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private static readonly string localPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private static readonly string pathToDb = localPath+@"\PartnerMatcherDB.accdb";
        private bool? isLoggedIn;
        public bool? IsLoggedIn
        {
            get
            {
                return isLoggedIn;
            }

            set
            {
                isLoggedIn = value;
                loginChanged();
            }
        }

        DatabaseUtils _dbUtils = new DatabaseUtils(pathToDb);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.ShowDialog();
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            IsLoggedIn = login.ShowDialog();
        }

        private void loginChanged()
        {
            if (IsLoggedIn == true)
            {
                button_login.Visibility = Visibility.Hidden;
                button_signup.Visibility = Visibility.Hidden;
                button_logout.Visibility = Visibility.Visible;
                gird_search.Visibility = Visibility.Visible;
            }
            else if(isLoggedIn == false)
            {
                button_logout.Visibility = Visibility.Hidden;
                button_login.Visibility = Visibility.Visible;
                button_signup.Visibility = Visibility.Visible;
                gird_search.Visibility = Visibility.Hidden;
            }
        }

        private void button_findMatch_Click(object sender, RoutedEventArgs e)
        {

            List<Ad> adList = null;
            if (tb_category.Text == "" || tb_location.Text == "")
            {
                MessageBox.Show("קלט לא חוקי");
            }
            else
            {
                try
                {
                    adList = _dbUtils.getAdsByLocationAndCategory(tb_location.Text, tb_category.Text);
                   if (adList != null)
                       printAdsToList(adList);
                   else
                       MessageBox.Show("מצטערים, לא מצאנו.אנא נסה שוב עם קטגוריה או מיקום שונים.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                  
                }                           
            }
        }

        private void printAdsToList(List<Ad> adList)
        {
            AdResult adResult= new AdResult(adList);
            adResult.ShowDialog();                     
        }

        private void button_logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("בטוח שברצונך להתנתק?", "אישור", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                IsLoggedIn = false;
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
    }
}
