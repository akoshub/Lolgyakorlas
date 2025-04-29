using Lolgyakorlas;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LolWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Hos> hosok = new List<Hos>();
        public MainWindow()
        {
            InitializeComponent();
            Feltoltes();
        }

        private void Btn_Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Mentes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Feltoltes()
        {
            foreach (var h in File.ReadAllLines("champions2017_V4.txt").Skip(1))
            {
                hosok.Add(new Hos(h));
            }
            Dg_Adatok.ItemsSource = hosok;
            Cbx_Szuro.ItemsSource = hosok;
        }
    }
}
