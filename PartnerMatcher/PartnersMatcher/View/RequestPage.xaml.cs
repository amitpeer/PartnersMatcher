﻿using PartnersMatcher.Model;
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
        private User user;
        private Ad ad;

        public RequestPage(User user, Ad ad)
        {
            InitializeComponent();
            Background = ((MainWindow)Application.Current.MainWindow).Background;
            this.user = user;
            this.ad = ad;
        }
    }
}
