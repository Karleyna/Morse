using System;
using System.Collections.Generic;
using System.IO;

namespace Morse_Translator
{
    public static class Translatоr
    {
        private static readonly Dictionary<char, string> To_Morse = new Dictionary<char, string> { };
        private static readonly Dictionary<string, char> From_Morse = new Dictionary<string, char> { };

        public static void SetDictionary(string language)
        {
            if (language == "rus")
            {
                using (StreamReader fstream = new StreamReader("dictionary_rus.txt"))
                {
                    string str = "";
                    while (!fstream.EndOfStream)
                    {
                        str = fstream.ReadLine();
                        To_Morse.Add(str[0], str.Substring(1, str.Length - 1));
                        From_Morse.Add(str.Substring(1, str.Length - 1), str[0]);
                    }
                }
            }

            if (language == "eng")
            {
                using (StreamReader fstream = new StreamReader("dictionary_eng.txt"))
                {
                    string str = "";
                    while (!fstream.EndOfStream)
                    {
                        str = fstream.ReadLine();
                        To_Morse.Add(str[0], str.Substring(1, str.Length - 1));
                        From_Morse.Add(str.Substring(1, str.Length - 1), str[0]);
                    }
                }
            }
        }

        /// <summary>
        /// перевод С английского и русского на Морзе и наоборот
        /// </summary>
        /// <param name="i"></param>

        public static void TranslateToMorse(StreamReader fReader)
        {
            char in_str;

            using (StreamWriter fWriter = new StreamWriter("output.txt", false)) { }

            while (!fReader.EndOfStream)
            {
                in_str = Convert.ToChar(fReader.Read());

                in_str = Convert.ToChar(Convert.ToString(in_str).ToUpper());

                using (StreamWriter fWriter = new StreamWriter("output.txt", true))
                {
                    try
                    {
                        fWriter.Write(To_Morse[Convert.ToChar(in_str)] + " ");
                    }
                    catch
                    {
                        fWriter.Write("   ");
                    }

                }
            }
        }

        public static void TranslateFromMorse(StreamReader fReader)
        {
            string in_str = "";
            char symbol;
            int countProbel = 0;

            using (StreamWriter fWriter = new StreamWriter("output.txt", false)) { }

            while (!fReader.EndOfStream)
            {
                while ((symbol = Convert.ToChar(fReader.Read())) != ' ')
                {
                    in_str += symbol;
                }

                countProbel++;

                using (StreamWriter fWriter = new StreamWriter("output.txt", true))
                {
                    try
                    {
                        fWriter.Write(From_Morse[in_str]);
                        countProbel = 0;
                    }
                    catch
                    {
                        if (countProbel > 1)
                        {
                            fWriter.Write(" ");
                            countProbel = 0;
                        }
                    }
                }

                in_str = "";
            }
        }
    }
}
