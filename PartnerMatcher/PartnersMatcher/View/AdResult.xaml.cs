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
using PartnersMatcher.Model;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for AdResult.xaml
    /// </summary>
    public partial class AdResult : Window
    {
        private List<Ad> adList;

        public List<Ad> AdList
        {
            get { return adList; }
            set { adList = value; }
        }

        public AdResult(User user, List<Ad> adList)
        {
            InitializeComponent();
            AdList = adList;
            foreach (Ad ad in adList)
            {
                listview.Items.Add(new AdSummary(user, ad));
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

 
            
        }
    }
}
