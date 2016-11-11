using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WpfApplication2.Tests
{
    [TestClass()]
    public class MainWindowTests
    {

        [TestMethod()]
        public void EncryptTest()
        {
            string s = "12345";
            string expected = "gMo3uRgQdKaHeFC7n2KDbA==";
            string actual;
            actual = MainWindow.Encrypt(s);
            if(expected == actual)
            {
                Console.WriteLine("Enkryptaus on sama, se toimii");
            }
            else
            {
                Console.WriteLine("Jotain meni pieleen");
            }
            
        }

        [TestMethod()]
        public void DecryptionTest()
        {
            string s = "gMo3uRgQdKaHeFC7n2KDbA==";
            string actual = MainWindow.Decrypt(s);
            string expected = "12345";

            if(expected == actual)
            {
                Console.WriteLine("Dekryptaus toimii");
            }
            else
            {
                Console.WriteLine("Jotain meni pieleen");
            }
        }


        [TestMethod()]
        public void GenerateTest()
        {
            MainWindow.n = 5;
            MainWindow.sallitut = "abcdefghijklmnopqrstuvwxyzåöä";
            string s = MainWindow.Generate();
            Thread.Sleep(1000);
            string s1 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s2 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s3 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s4 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s5 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s6 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s7 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s8 = MainWindow.Generate();
            Thread.Sleep(1000);
            string s9 = MainWindow.Generate();



            Console.WriteLine(s);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
            Console.WriteLine(s9);


        }

  
    }
}