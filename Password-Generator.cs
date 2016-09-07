using System;
using System.IO;


public class laskin
{
     // moduuli luo halutun pituisen salasanan sallituista kirjaimista.
    public static string generoi(int pituus)
    {
        string sallitut = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
        char[] kirjaimet = new char[pituus];
        Random rand = new Random();

        for(int i = 0; i < pituus; i++)
        {
            kirjaimet[i] = sallitut[rand.Next(0, sallitut.Length)];
        }
        return new string(kirjaimet);
    }


    public static void Main(string[] args)
    {
        

        Console.WriteLine("Hei! Tervetuloa käyttämään ohjelmaa!\n");

        int valinta = 0;
        while( valinta != 6){               // While looppi pyörittää ohjelman ydintä

            Console.WriteLine("Mitä haluat tehdä?");
            Console.WriteLine("(1)Generoi uusi salasana");
            Console.WriteLine("(2)Tallenna salasana tiedostoon");
            Console.WriteLine("(3)Poista tiedosto");
            Console.WriteLine("(4)");
            Console.WriteLine("(5)");
            Console.WriteLine("(6)Lopettaa ohjelman");

           string syote = Console.ReadLine();
           valinta = int.Parse(syote);


            if (valinta == 1)
            {
                Console.WriteLine("Kuinka pitkän salasanan haluat?");
                string syote2 = Console.ReadLine();
                int pituus = int.Parse(syote2);
                string uusiSalasana = (generoi(pituus));
                Console.WriteLine(generoi(pituus));
                
            }

            if (valinta == 2)
            {
                Console.WriteLine("Syötä tiedosto polku mihin haluat tallentaa salasanan");
                string tiedosto = Console.ReadLine();

            }

            if (valinta == 3)
            {

            }

            if (valinta == 4)
            {

            }

            if (valinta == 5)
            {

            }

            if (valinta == 6)
            {
                Console.WriteLine("Kiitos kun käytit ohjelmaa!");
            }
                
            
         
        }
    


    }
}