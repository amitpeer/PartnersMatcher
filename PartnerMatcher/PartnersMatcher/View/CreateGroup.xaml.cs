using PartnersMatcher.Controller;
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
    /// Interaction logic for CreateGroup.xaml
    /// </summary>
    public partial class CreateGroup : Window
    {
        private IController controller;

        public CreateGroup(IController controller)
        {
            this.Background = ((MainWindow)Application.Current.MainWindow).Background;
            InitializeComponent();
            this.controller = controller;
        }

        private void location_loaded(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).location_loaded(sender, e);
        }

        private void catagory_loaded(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).catagory_loaded(sender, e);
        }

        private void tb_location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).tb_location_SelectionChanged(sender, e);
        }

        private void tb_catagory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).tb_catagory_SelectionChanged(sender, e);
        }

        private void button_createGroup_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_title.Text == "" || textBox_adContent.Text == "" || textBox_groupContent.Text == "" || comboBox_category.SelectedIndex == 0 || comboBox_location.SelectedIndex == 0)
            {
                MessageBox.Show("אנא מאל את כל הפרטים");
            }
            else
            {
                controller.createNewGroup(comboBox_category.Text, comboBox_location.Text, textBox_title.Text, textBox_adContent.Text, textBox_groupContent.Text);
            }
        }
    }
}
