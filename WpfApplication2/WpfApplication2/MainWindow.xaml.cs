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
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using System.Net.Mail;
using WpfApplication2;
using System.Diagnostics;

namespace WpfApplication2
{
    public partial class MainWindow : Window
    {

        public static string sallitut = "";
        public string lowerCase = "abcdefghijklmnopqrstuvwxyzåöä";
        public string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÖÄ";
        public string symbols = "!@$?_-";
        public string nums = "0123456789";
        public static int n;
        public static string passw;
        public bool tila = false;
        

        static readonly string passwordHash = "P@@Sw0rd";
        static readonly string saltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public MainWindow()
        {
            
            InitializeComponent();                                     
            //new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "C://Users//Santun//Password-Generator//WpfApplication2//lataus.jpg")));

            if (comboBox.Text == "Length" && tila == true)
            {
                button.IsEnabled = false;
            }
            
        
        }

        public static string Generate()
        {
            int pituus = n;
            char[] kirjaimet = new char[pituus];
            Random rand = new Random();

            for (int i = 0; i < pituus; i++)
            {
                kirjaimet[i] = sallitut[rand.Next(0, sallitut.Length)];       
            }
            string salasana = new string(kirjaimet);
            return salasana;
        }
            
        private void button_Click(object sender, RoutedEventArgs e)
        {  
                    // Generoi salasanan ja kirjoittaa sen richTextBoxiin


            string salasana = Generate();
            passw = salasana;
            richTextBox.Document.Blocks.Clear();
            richTextBox.AppendText(passw);
            BtnSend.IsEnabled = true;
               
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            string myString = ((ComboBoxItem)comboBox.SelectedItem).Content.ToString();
            n = int.Parse(myString);
            
            if (n < 8)
                MessageBox.Show("Warning! It's not safe to have a password under 8 characters!");

            //ottaa comboboxin valitun ja muuttaa sen intiksi
        }

      

        // CHECCKAUKSET
        private void UpperCase_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += upperCase;
            if (sallitut == "")
            {
               tila = button.IsEnabled = false;
            }
            else
               tila = button.IsEnabled = true;

        }
        private void Symbols_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += symbols;
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;

        }

        private void LowerCase_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += lowerCase;
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;
        }

        private void Numbers_Checked(object sender, RoutedEventArgs e)
        {
            sallitut += nums;
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;
        }


                    // UNCHECKKAUSET

        private void Numbers_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(nums, "");
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;

        }

        private void LowerCase_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(lowerCase, "");
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;

        }

        private void Symbols_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(symbols, "");
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;

        }

        private void UpperCase_Unchecked(object sender, RoutedEventArgs e)
        {
            sallitut = sallitut.Replace(upperCase, "");
            if (sallitut == "")
            {
                tila = button.IsEnabled = false;
            }
            else
                tila = button.IsEnabled = true;

        }

        // Ottaa parametrina generoidun salasanan  ja enkryptaa sen
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(passwordHash, Encoding.ASCII.GetBytes(saltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();

            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        // Dekryptaa salatun salasanan ja palauttaa sen
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(passwordHash, Encoding.ASCII.GetBytes(saltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
                
        // Avaa Send Email ikkunan
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {

            Window1 win2 = new Window1();
            win2.Show();
        }

        // Avaa Encryption ikkunan
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 win3 = new Window2();
            win3.Show();
        }

        // Avaa Tips ikkunan
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window3 win4 = new Window3();
            win4.Show();
        }

        // Linkki Nettisivulle, jossa voi testata salasanan vahvuutta
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        // Kopiointi nappula
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.SelectAll();
            richTextBox.Copy();
        }

    }
}
