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
    /// Interaction logic for RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Window
    {
        private IController controller;
        private Ad ad;

        public RequestPage(Ad ad, IController controller)
        {
            InitializeComponent();
            Background = ((MainWindow)Application.Current.MainWindow).Background;
            this.ad = ad;
            this.controller = controller;

            // fill the labels with the Ad details
            label_admin.Content = ad.Admin;
            label_category.Content = ad.Category;
            label_location.Content = ad.Location;
            label_title.Content = ad.Title;
            label_content.Content = ad.Content;
        }

        private void button_send_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("?האם ברצונך לשלוח בקשת הצטרפות לקבוצה זו", "אישור", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                controller.addRequest(ad.SerialNumber);
                Close();
            }
        }

        private void button_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
