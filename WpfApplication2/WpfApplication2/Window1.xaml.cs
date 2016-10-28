using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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


namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public string userMail;

        public Window1()
        {
            InitializeComponent();
        }

        // Lähettää sähköpostin kun nappia painaa! :))
        private void button_Click(object sender, RoutedEventArgs e)
        {
        
            
                 try
            {
                MailMessage mail = new MailMessage();
                //SMTP address and port here
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587 );
                //Put the email address
                mail.From = new MailAddress("wikke93@gmail.com");
                //Put the email where you want to send.
                mail.To.Add(userMail);                 //pwgenerator93@gmail.com on testi boxi

                mail.Subject = "Generoitu Salasana";

                StringBuilder sbBody = new StringBuilder();

                sbBody.AppendLine("Hello User!");
                sbBody.AppendLine("Here's your encrypted password!");
                sbBody.AppendLine(WpfApplication2.MainWindow.Encrypt(WpfApplication2.MainWindow.passw));
                sbBody.AppendLine("You can decrypt the password by using our software and the Encryption window.");
                sbBody.AppendLine("Have a wonderful day!");
                
                

                mail.Body = sbBody.ToString();

                SmtpServer.Credentials = new System.Net.NetworkCredential("pwgenerator93@gmail.com", "aspretto");
                //Set Smtp server port
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("The password was sent to: " + userMail);

            } 
            catch (Exception ex)
            {
                MessageBox.Show("Check you Email address");
                Console.WriteLine(ex.ToString());
            } 
            this.Close(); 
            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (WpfApplication2.MainWindow.sallitut == "")
            {
                button.IsEnabled = false;
            }
            else
                button.IsEnabled = true;
            userMail = textBox.Text;
        }
    }
}
