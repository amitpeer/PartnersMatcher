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
using PartnersMatcher.Model;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for AdSummary.xaml
    /// </summary>
    public partial class AdSummary : UserControl
    {
        Ad ad;
        public AdSummary(Ad ad)
        {
            InitializeComponent();
            this.ad = ad;
            category1.Text = ad.Category;
            adid1.Text = ad.SerialNumber.ToString();
            Location1.Text = ad.Location;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("שירות זה אינו זמין כרגע");
        }
    }
}
