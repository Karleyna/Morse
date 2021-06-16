using System;
using System.IO;
using Morse_Translator;

namespace Morse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Translation: \n1: from English to Morse \n2: from Morse to English \n3: from Russian to Morse \n4: from Morse to Russian");
            int i = 0;
            if (!Int32.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Are you sure that you understand me?");
            }
            else if (i > 4 || i <= 0)
            {
                Console.WriteLine("There is no such option");
            }
            else
            {
                using (StreamReader fReader = new StreamReader("read.txt"))
                {
                    if (i == 1)
                    {
                        Translatоr.SetDictionary("eng"); 
                        Translatоr.TranslateToMorse(fReader);
                    }
                    if (i == 2)
                    {
                        Translatоr.SetDictionary("eng");
                        Translatоr.TranslateFromMorse(fReader);
                    }
                    if (i == 3)
                    {
                        Translatоr.SetDictionary("rus");
                        Translatоr.TranslateToMorse(fReader);
                    }
                    if (i == 4)
                    {
                        Translatоr.SetDictionary("rus");
                        Translatоr.TranslateFromMorse(fReader);
                    }
                }                   
            }
        }
    }
}
