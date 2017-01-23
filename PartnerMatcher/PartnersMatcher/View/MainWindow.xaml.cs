using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using PartnersMatcher.Controller;
using PartnersMatcher.Model;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window,IView
    {
        static readonly string localPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private IController controller;
        List<string> _location;
        List<string> _category;
        private bool? isLoggedIn;
        private User user;
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
        public MainWindow()
        {
            loadLocationsAndCategorys();
            InitializeComponent();
            IModel model = new PMModel();
            controller = new PMController(this, model);
            model.setController(controller);
        }

        private void loadLocationsAndCategorys()
        {
            StreamReader srLocations = new StreamReader(localPath + @"\Data\location.txt", System.Text.ASCIIEncoding.Default);                                  //the constructor 
            StreamReader srCategorys = new StreamReader(localPath + @"\Data\category.txt", System.Text.ASCIIEncoding.Default);                             //reach both from file
            string locations = srLocations.ReadToEnd();
            string categorys = srCategorys.ReadToEnd();
            srLocations.Close();
            srCategorys.Close();
            string[] splitLocations = locations.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);                                                            //look at the file format
            string[] splitCategorys = categorys.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            _location = splitLocations.ToList();
            _category = splitCategorys.ToList();
        }

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup(controller);
            signup.ShowDialog();
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(controller);
            IsLoggedIn = login.ShowDialog();
        }

        private void loginChanged()
        {
            tb_location.SelectedIndex = 0;
            tb_location.SelectedIndex = 0;
            if (IsLoggedIn == true)
            {
                button_login.Visibility = Visibility.Hidden;
                button_signup.Visibility = Visibility.Hidden;
                button_logout.Visibility = Visibility.Visible;
                gird_search.Visibility = Visibility.Visible;
                label_welcome.Content = Regex.IsMatch(user.FirstName, "^[a-zA-Z0-9]*$") ? user.FirstName + " שלום" : "שלום " + user.FirstName;
                label_welcome.Visibility = Visibility.Visible;
            }
            else if (isLoggedIn == false)
            {
                button_logout.Visibility = Visibility.Hidden;
                button_login.Visibility = Visibility.Visible;
                button_signup.Visibility = Visibility.Visible;
                gird_search.Visibility = Visibility.Hidden;
                label_welcome.Visibility = Visibility.Hidden;
            }
        }

        public void notifyMe(User user)
        {
            this.user = user;
        }

        private void button_findMatch_Click(object sender, RoutedEventArgs e)
        {      
            List<Ad> adList = null;
            if (tb_category.SelectedIndex==0 || tb_location.SelectedIndex == 0)
            {
                MessageBox.Show("קלט לא חוקי");
            }
            else
            {
                    adList = controller.getAdsByLocationAndCategory(tb_location.Text, tb_category.Text);
                    if (adList != null && adList.Count>0)
                        printAdsToList(adList);
                    else
                        MessageBox.Show(".מצטערים, לא מצאנו.אנא נסה שוב עם קטגוריה או מיקום שונים");
            }
        }

        private void printAdsToList(List<Ad> adList)
        {
            AdResult adResult = new AdResult(adList);
            adResult.ShowDialog();
        }

        private void button_logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("בטוח שברצונך להתנתק?", "אישור", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                IsLoggedIn = false;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }

        private void location_loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = _location;
            comboBox.SelectedIndex = 0;
        }

        private void tb_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.Text = comboBox.SelectedItem as string;
        }

        private void catagory_loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = _category;
            comboBox.SelectedIndex = 0;
        }

        private void tb_catagory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.Text = comboBox.SelectedItem as string;
        }

        public void showMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}
