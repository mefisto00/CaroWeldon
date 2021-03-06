﻿using System;
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

namespace CaroSYSTEM2809
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string login;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string xlogin)
        {
            InitializeComponent();
            login = xlogin;
        }

        private void BDodajNowaUmowaBTN_Click(object sender, RoutedEventArgs e)
        {
            oknoNowaUmowa nowaUmowa = new oknoNowaUmowa(login);
            nowaUmowa.Show();
        }

        private void BPrzegladajBTN_Click(object sender, RoutedEventArgs e)
        {
            oknoEksplorator eksplorator = new oknoEksplorator();
            eksplorator.Show();
        }

        private void BRaportyBTN_Click(object sender, RoutedEventArgs e)
        {
            oknoRaporty raporty = new oknoRaporty();
            raporty.Show();
        }
    }
}
