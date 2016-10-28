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
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public string EncrPw;
        


        public Window2()
        {
            InitializeComponent();

           
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EncrPw = textBox.Text;
                richTextBox.Document.Blocks.Clear();
                richTextBox.AppendText(WpfApplication2.MainWindow.Decrypt(EncrPw));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check the password you are trying to decrypt");
            }
        }

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
            textBox.AppendText(Clipboard.GetText());
        }
    }
}
