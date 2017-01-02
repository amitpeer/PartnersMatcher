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

        static readonly string localPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private static readonly string pathToDb = localPath+@"\PartnerMatcherDB.accdb";
        private bool? isLoggedIn;

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
            isLoggedIn = login.ShowDialog();
            MessageBox.Show(isLoggedIn == true? "yes" : "no");
        }

        private void button_findMatch_Click(object sender, RoutedEventArgs e)
        {

            List<Ad> adList = null;
            if (tb_category.Text == "" || tb_location.Text == "")
            {
                MessageBox.Show("Bad input");
            }
            else
            {
                try
                {
                    adList = _dbUtils.getAdsByLocationAndCategory(tb_location.Text, tb_category.Text);
                   if (adList != null)
                       printAdsToList(adList);
                   else
                       MessageBox.Show("Found nothing, try again with different details");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                  
                }
               

                
            }
        }

        private void printAdsToList(List<Ad> adList)
        {
            throw new NotImplementedException();
        }
    }
}
