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
            Feltoltes();
        }

        private void Btn_Mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tartalom = "";
                string fajlnev = Cbx_Szuro.SelectedValue.ToString() + ".txt";
                foreach (var hos in hosok)
                {
                    tartalom += $"{hos.Name};{hos.Title};{hos.Category};{hos.Tag};{hos.Hp};{hos.Attackdamage};{hos.Attackdamageperlevel}\n";
                }
                StreamWriter fajlbair = new StreamWriter(fajlnev);
                fajlbair.WriteLine(tartalom);
                fajlbair.Close();
                MessageBox.Show("sikeres mentés");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Feltoltes()
        {
            string szurok = "name;title;category;tag;hp;attackdamage;attackdamageperlevel";
            Cbx_Szuro.ItemsSource = szurok.Split(';');
            hosok.Clear();
            foreach (var h in File.ReadAllLines("champions2017_V4.txt").Skip(1))
            {
                hosok.Add(new Hos(h));
            }
            Dg_Adatok.ItemsSource = null;
            Dg_Adatok.ItemsSource = hosok;
        }

        private void Cbx_Szuro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string szuro = Cbx_Szuro.SelectedValue.ToString();
            if (szuro == "name")
            {
                hosok.Sort((a, b) => b.Name.CompareTo(a.Name));
            }
            else if (szuro == "title")
            {
                hosok.Sort((a, b) => b.Title.CompareTo(a.Title));
            }
            else if (szuro == "category")
            {
                hosok.Sort((a, b) => b.Category.CompareTo(a.Category));
            }
            else if (szuro == "tag")
            {
                hosok.Sort((a, b) => b.Tag.CompareTo(a.Tag));
            }
            else if (szuro == "hp")
            {
                hosok.Sort((a, b) => b.Hp.CompareTo(a.Hp));
            }
            else if (szuro == "attackdamage")
            {
                hosok.Sort((a, b) => b.Attackdamage.CompareTo(a.Attackdamage));
            }
            else if (szuro == "attackdamageperlevel")
            {
                hosok.Sort((a, b) => b.Attackdamageperlevel.CompareTo(a.Attackdamageperlevel));
            }
            Dg_Adatok.Items.Refresh();
        }
    }
}
