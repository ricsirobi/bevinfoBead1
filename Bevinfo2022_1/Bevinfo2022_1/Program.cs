﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Bevinfo2022_1
{
    internal class Program
    {
        public static String CowSay(string text)
        {
            int h = text.Length;
            string top = "__";
            string bot = "----";
            for (int i = 0; i < text.Length; i++)
            {
                if (!text.Contains("\n"))
                {
                    top += "_";
                    bot += "-";
                }
                else
                {
                    string[] temp = text.Split('\n');
                    if (i % temp.Length == 0)
                    {
                        top += "_";
                        bot += "-";
                    }

                }

            }
            string toReturn = top + " \n" +
                    "< " + text + " >\n" +
                    "" + bot +
                    "      \n\t   \\^__^\n" +
                    "         \\  (oo)\\_______\n" +
                    "            (__)\\       )\\/\\ " + "\n" +
                    "                ||----w |\n" +
                    "                ||     ||";
            Console.WriteLine(toReturn);
            return toReturn;
        }

        //Változók
        static string inputString;
        static int inputInt;

        //FÜGGVÉNYEK

        //Segítség
        public static void help()
        {
            CowSay("octHexConverter\nKészítette Bodnár Máté");
            CowSay("Kezdetnek írd be, hogy \"8-16\" vagy \"16-8\". \nEzzel kiválaszthatod azt, hogy milyen számrendszerből hova váltunk.\n");
        }

        //Validáció
        public static bool isOctNumber()
        {
            for (int i = 0; i < inputString.Length - 1; i++)
            {
                if (int.TryParse(inputString, out int temp2))
                {
                    if (int.Parse(inputString.Substring(i, 1)) > 7 || int.Parse(inputString.Substring(i, 1)) < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool isHexNumber()
        {
            inputString = inputString.ToUpper();
            for (int i = 0; i < inputString.Length - 1; i++)
            {
                if (int.TryParse(inputString.Substring(i, 1), out int temp))
                {
                    if (int.Parse(inputString.Substring(i, 1)) < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (inputString.Substring(i, 1) != "A" &&
                        inputString.Substring(i, 1) != "B" &&
                        inputString.Substring(i, 1) != "C" &&
                        inputString.Substring(i, 1) != "D" &&
                        inputString.Substring(i, 1) != "E" &&
                        inputString.Substring(i, 1) != "F")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Fő
        public static void chooseChangeType()
        {
            CowSay("Írd be, hogy melyik számrendszerből melyikbe szeretnél váltani.");
            CowSay("(8-16 vagy 16-8)");
            string answer = Console.ReadLine();
            while (!(answer == "8-16") && !(answer == "16-8"))
            {
                CowSay("Ezt írtad: {" + answer + "}");

                CowSay("Helytelen bevitt szöveg.\n(8-16 vagy 16-8)\nPróbáld újra\t");

                answer = Console.ReadLine();
            }
            switch (answer)
            {
                case "8-16":
                    exchangeFromOct();
                    break;
                case "16-8":
                    exchangeFromHex();
                    break;
            }
        }



        //Átváltás elvégzése
        public static void exchangeFromOct()
        {
            //
            CowSay("Írj be egy 8-as számrendszerbeli számot");
            inputString = Console.ReadLine();
            while (!isOctNumber())
            {
                CowSay("Próbáld újra\n");
                inputString = Console.ReadLine();
                Console.WriteLine();

            }
            //
            Console.WriteLine("(:--------------------------------------------------------------:)");
            CowSay("OCT: {" + inputString + "}");
            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("OCT  TO  BIN");
            Console.WriteLine("////////////////////////////////////////////////////////");
            //PÉLDA
            //666 -> 110 110 110
            //12345 -> 110110110 110110... 1010110 110110110 3-assval váltjuk egyenként 


            string resultBin = exchangeFromOctToBin(inputString);
            CowSay("BIN: {" + resultBin + "}");

            Console.WriteLine("////////////////////////////////////////////////////////");
            Console.WriteLine("BIN  TO  HEX");
            Console.WriteLine("////////////////////////////////////////////////////////");

            switch (resultBin.Length % 4)
            {
                case 1: resultBin = "000" + resultBin; break;
                case 2: resultBin = "00" + resultBin; break;
                case 3: resultBin = "0" + resultBin; break;
                default: break;
            }
            string resultHex = exchangeFromBinToHex(resultBin);
            CowSay("HEX: {" + resultHex + "}");

        }
        public static void exchangeFromHex()
        {
            //
            CowSay("Írj be egy 16-os számrendszerbeli számot");
            inputString = Console.ReadLine();
            while (!isHexNumber())
            {
                CowSay("Próbáld újra");
                inputString = Console.ReadLine();

            }//

            CowSay("MOST FOGOK VÁLTANI 16-osból");
        }
        public static string exchangeFromOctToBin(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                switch (input.Substring(i, 1))
                {
                    case "0": result += "000"; break;
                    case "1": result += "001"; break;
                    case "2": result += "010"; break;
                    case "3": result += "011"; break;
                    case "4": result += "100"; break;
                    case "5": result += "101"; break;
                    case "6": result += "110"; break;
                    case "7": result += "111"; break;
                    default: result += "000"; break;
                }
            }


            return result;
        }
        public static string exchangeFromBinToHex(string input)
        {
            string result = "";
            List<string> list = new List<string>();
            for (int i = 0; i < input.Length - 3; i += 4)
            {
                //CowSay("forban vagyok, i=" + i);
                switch (input.Substring(i, 4))
                {
                    case "0000": list.Add("0"); break;
                    case "0001": list.Add("1"); break;
                    case "0010": list.Add("2"); break;
                    case "0011": list.Add("3"); break;
                    case "0100": list.Add("4"); break;
                    case "0101": list.Add("5"); break;
                    case "0110": list.Add("6"); break;
                    case "0111": list.Add("7"); break;
                    case "1000": list.Add("8"); break;
                    case "1001": list.Add("9"); break;
                    case "1010": list.Add("A"); break;
                    case "1011": list.Add("B"); break;
                    case "1100": list.Add("C"); break;
                    case "1101": list.Add("D"); break;
                    case "1110": list.Add("E"); break;
                    case "1111": list.Add("F"); break;

                    default: list.Add("0"); break;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
            }

            return result;
        }


        static void Main(string[] args)
        {
            chooseChangeType();


            Console.WriteLine("===================================================================");
            Console.WriteLine("Program vége,nyomj egy gombot a kilépéshez");
            Console.ReadKey();
        }
    }
}