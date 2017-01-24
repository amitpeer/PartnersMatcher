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
using PartnersMatcher.Controller;

namespace PartnersMatcher.View
{
    /// <summary>
    /// Interaction logic for AdResult.xaml
    /// </summary>
    public partial class AdResult : Window
    {
        private List<Ad> adList;
        private IController controller;

        public List<Ad> AdList
        {
            get { return adList; }
            set { adList = value; }
        }

        public AdResult(IController controller, List<Ad> adList)
        {
            InitializeComponent();
            AdList = adList;
            this.controller = controller;
            foreach (Ad ad in adList)
            {
                 listview.Items.Add(new AdSummary(ad, controller));
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
