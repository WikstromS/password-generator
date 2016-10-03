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

        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public MainWindow()
        {
            
            InitializeComponent();                                      // TÄYTYY KEKSIÄ PAREMPI VAIHTOEHTO
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
            MessageBox.Show(Encrypt(salasana));
            MessageBox.Show(Decrypt(Encrypt(salasana)));
             
            
            
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

        // Ottaa parametrina generoidun salasanan  ja enkryptaa sen
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
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
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
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


                // Lähettää sähköpostin kun nappia painaa! :))
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //SMTP address and port here
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587 );
                //Put the email address
                mail.From = new MailAddress("wikke93@gmail.com");
                //Put the email where you want to send.
                mail.To.Add("kekkosenseppo@gmail.com");

                mail.Subject = "Generoitu Salasana";

                StringBuilder sbBody = new StringBuilder();

                sbBody.AppendLine("Hei käyttäjä!");
                sbBody.AppendLine("Tässä salasanasi!");
                sbBody.AppendLine("Salasana tähän!");

                mail.Body = sbBody.ToString();

                //mail.Attachments.Add(liite) tällä tavalla salasanan lähetys?

                //username and password!

                SmtpServer.Credentials = new System.Net.NetworkCredential("wikke93@gmail.com", "Heinekenmerkkihiha1");
                //Set Smtp server port
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Salasana lähetettiin :) ");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
