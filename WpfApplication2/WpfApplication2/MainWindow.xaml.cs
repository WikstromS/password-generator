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

        public string sallitut = "";
        public string LowerCase = "abcdefghijklmnopqrstuvwxyzåöä";
        public string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÖÄ";
        public string Symbols = "!@$?_-";
        public string nums = "0123456789";
        public int N;

        public MainWindow()
        {
            
            InitializeComponent();
            new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "C:\\Users\\Santun\\Password-Generator\\WpfApplication2\\lataus.jpg")));

        }
        
            
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // GENEROI SALASANAN
            int pituus = N;
            char[] kirjaimet = new char[pituus];
            Random rand = new Random();

            for (int i = 0; i < pituus; i++)
            {
                kirjaimet[i] = sallitut[rand.Next(0, sallitut.Length)];         //TOIMII 
            }

            string salasana = new string(kirjaimet);
            MessageBox.Show(salasana);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string myString = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
            N = int.Parse(myString);
            if (N < 8)
                MessageBox.Show("Warning! It's not safe to have a password under 8 characters!");

            //ottaa comboboxin valitun ja muuttaa sen intiksi
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // CHECCKAUKSET
        private void upperCase_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += UpperCase;
            
            
        }
        private void symbols_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += Symbols;
            

        }

        private void lowerCase_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += LowerCase;
        }

        private void numbers_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += nums;
        }


                    // UNCHECKKAUSET

        private void numbers_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(nums, "");
            
        }

        private void lowerCase_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(LowerCase, "");
            
        }

        private void symbols_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(Symbols, "");
           
        }

        private void upperCase_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(UpperCase, "");
            
        }

     
    }
}
