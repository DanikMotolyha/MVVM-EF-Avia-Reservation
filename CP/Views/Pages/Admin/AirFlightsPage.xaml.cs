﻿using CP.ViewModels;
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

namespace CP.Views
{
    /// <summary>
    /// Логика взаимодействия для AirFlightsPage.xaml
    /// </summary>
    public partial class AirFlightsPage : Page
    {
        public AirFlightsPage()
        {
            InitializeComponent();
            DataContext = new AirFlightsPageViewModel();
        }
    }
}
