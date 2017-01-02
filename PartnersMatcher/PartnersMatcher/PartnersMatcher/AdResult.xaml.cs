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
    /// Interaction logic for AdResult.xaml
    /// </summary>
    public partial class AdResult : Window
    {
        public AdResult(List<Ad> adList)
        {
            InitializeComponent();
            foreach (Ad ad in adList)
            {
                
                this.myGrid.Children.Add(new AdSummary(ad));
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

 

        }
    }
}
