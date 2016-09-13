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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int pituus = 10;
            string sallitut = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] kirjaimet = new char[pituus];
            Random rand = new Random();

            for (int i = 0; i < pituus; i++)
            {
                kirjaimet[i] = sallitut[rand.Next(0, sallitut.Length)];
            }

            string salasana = new string(kirjaimet);
            MessageBox.Show(salasana);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pituus;
            pituus = comboBox.Text;
            comboBox.Items.Add("5");
            comboBox.Items.Add("6");
            comboBox.Items.Add("7");
            comboBox.Items.Add("8");
            comboBox.Items.Add("9");
            comboBox.Items.Add("10");
            comboBox.Items.Add("11");
            comboBox.Items.Add("12");
            comboBox.Items.Add("13");
            comboBox.Items.Add("14");
            comboBox.Items.Add("15");
            comboBox.Items.Add("16");
            comboBox.Items.Add("17");
            comboBox.Items.Add("18");
            comboBox.Items.Add("19");
            comboBox.Items.Add("20");
            comboBox.Items.Add("21");
            comboBox.Items.Add("22");
            comboBox.Items.Add("23");
        }
    }
}
