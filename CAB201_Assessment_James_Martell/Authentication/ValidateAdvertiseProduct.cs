using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    internal class ValidateAdvertiseProduct
    {
        public static bool Name(string userInput)
        {
            bool TrueOrFalse = false;

            if (String.IsNullOrWhiteSpace(userInput) == false) { TrueOrFalse = true; }

            return TrueOrFalse;
        }
        public static bool Description(string userInput, string productName)
        {
            bool TrueOrFalse = false;

            if (String.IsNullOrWhiteSpace(userInput) == false)
            {
                if (Regex.IsMatch(userInput, $"{productName}") == false) { TrueOrFalse = true; }
            }

            return TrueOrFalse;
        }
        public static bool Price(string userInput)
        {
            bool TrueOrFalse = false;
            if (String.IsNullOrWhiteSpace(userInput) == false && userInput.IndexOf('$') == 0 && userInput.IndexOf('.') != -1)
            {
                //Input info
                string[] splitUserInput = userInput.Split(".", 2); //Split the input for simple validation steps
                int splitLocation = userInput.IndexOf('.'); //Find the index value of the split location

                // first half info
                int firstSplitSize = splitUserInput[0].Length - 1; // Find the length of the first split (before '.'
                string dollarValue = splitUserInput[0].Remove(0, 1); // Remove dollar sign                                                 
                bool dollarHasWhiteSpace = dollarValue.Any(x => Char.IsWhiteSpace(x));
                int intFirstOutput; // Placeholder for int output of tryparse
                bool firstIsInt = int.TryParse(dollarValue, out intFirstOutput); // check if dollar amount is int

                // second half info
                int intSecondOutput;
                bool secondIsInt = int.TryParse(splitUserInput[1], out intSecondOutput);
                int secondSplitSize = splitUserInput[1].Length - 1;

                if (dollarHasWhiteSpace == false && firstIsInt == true && splitLocation > firstSplitSize && secondIsInt == true && secondSplitSize == 1)
                {
                    TrueOrFalse = true;
                }
                
            }

            return TrueOrFalse;
        }
    }
}
