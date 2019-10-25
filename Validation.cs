using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolandLupi_ConvertedData
{
    class Validation
    {
        //int validation
        public static int GetInt()
        {
            int validatedInt;
            string input = Console.ReadLine();
            
            while (!Int32.TryParse(input, out validatedInt))
            {
                Console.Write("\r\nPlease Enter A Valid Input: ");
                input = Console.ReadLine();
            }
            Console.Clear();
            return validatedInt;
        }
        //int validation with a range
        public static int GetInt(int min, int max) 
        {
            int validatedInt;
            string input = Console.ReadLine();
           
            while (!(Int32.TryParse(input, out validatedInt) && (validatedInt >= min && validatedInt <= max)))
            {
                Console.Write("\r\nPlease Enter A Valid Input: ");
                input = Console.ReadLine();
            }
            Console.Clear();
            return validatedInt;

        }
        //bool validation
        public static bool GetBool(string message = "Enter Yes Or No:")
        {
            bool choice = false;
            string input = null;
            bool keepAsking = true;

            while (keepAsking)
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "y":
                    case "yes":
                    case "t":
                    case "n":
                    case "no":

                    case "true":
                        {
                            choice = true;
                            keepAsking = false;
                        }
                        break;
                    case "false":
                        {
                            keepAsking = false;
                        }
                        break;
                }
            }
            return choice;
        }
        //double validation
        public static double GetDouble(string message = "Enter A Number: ")
        {
            double validatedInt;
            string input = null;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (!double.TryParse(input, out validatedInt));

            return validatedInt;
        }
        //double validation with range
        public static double GetDouble(int min, int max, string message = "Enter A Number: ") 
        {
            double validatedDouble;
            string input = null;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            }
            while (!(double.TryParse(input, out validatedDouble) && (validatedDouble >= min && validatedDouble <= max)));

            return validatedDouble;


        }

        // string validation
        public static string GetString()
        {
            string validatedString = null;

            validatedString = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(validatedString))
            {
                Console.Write("\r\nPlease Enter A Valid Input: ");
                validatedString = Console.ReadLine();
                
            }
            Console.Clear();
            return validatedString;
        }

        //decimal validation
        public static decimal GetDecimal()
        {
            decimal validatedDecimal;
            string input = Console.ReadLine();

            while (!decimal.TryParse(input, out validatedDecimal))
            {
                Console.Write("\r\nPlease Enter A Valid Input: ");
                input = Console.ReadLine();
            }
            Console.Clear();
            return validatedDecimal;

        }

        //float validation
        public static float GetFloat()
        {
            float validatedFloat;
            string input = Console.ReadLine();

            while (!float.TryParse(input, out validatedFloat))
            {
                Console.Write("\r\nPlease Enter A Valid Input: ");
                input = Console.ReadLine();
            }
            Console.Clear();
            return validatedFloat;
        }
    }
}
