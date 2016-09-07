using System;
using System.IO;


public class laskin
{

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
       Console.WriteLine("Hei! Tervetuloa käyttämään ohjelmaa.\nKuinka pitkän salasanan haluat? ");
       // Otetaan käyttäjältä syöte, kuinka pitkän salasanan hän haluaa.
       string valinta = Console.ReadLine(); 
       int pituus =  int.Parse(valinta);
  

        generoi(pituus);

        Console.WriteLine(generoi(pituus));


    }
}