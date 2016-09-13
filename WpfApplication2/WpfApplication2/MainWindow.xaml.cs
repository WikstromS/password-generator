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
            new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "C:\\Users\\Toni\\Documents\\GitHub\\password-generator\\WpfApplication2\\lataus.jpg")));
           
            

        }
        
            
        private void button_Click(object sender, RoutedEventArgs e)
        {

            int pituus = 10;
            string sallitut = "";
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÖÄ";
            string symbols = "!@$?_-";
            string nums = "0123456789";
           
            char[] kirjaimet = new char[pituus];
            Random rand = new Random();

            if(upperCase.)

            for (int i = 0; i < pituus; i++)
            {
                kirjaimet[i] = sallitut[rand.Next(0, sallitut.Length)];
            }

            string salasana = new string(kirjaimet);
            MessageBox.Show(salasana);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
  
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void upperCase_Checked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
