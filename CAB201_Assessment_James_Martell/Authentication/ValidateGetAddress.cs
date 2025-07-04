using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ValidateGetAddress
    {
        public static bool UnitNumber(string userInput)
        {
            bool TrueOrFalse = false;
            int a;
            if (String.IsNullOrWhiteSpace(userInput) == false & int.TryParse(userInput, out a) == true)
            {
                int userInputInt = int.Parse(userInput);

                if (userInputInt > 0)
                {
                    TrueOrFalse = true;
                }
            }

            return TrueOrFalse;
        }
        public static bool StreetNumber(string userInput)
        {
            bool TrueOrFalse = false;
            int a;
            if (String.IsNullOrWhiteSpace(userInput) == false & int.TryParse(userInput, out a) == true)
            {
                int userInputInt = Int32.Parse(userInput);

                if (userInputInt > 0)
                {
                    TrueOrFalse = true;
                }
            }

            return TrueOrFalse;
        }
        public static bool StreetNameAndCity(string userInput)
        {
            bool TrueOrFalse = false;

            if (String.IsNullOrWhiteSpace(userInput) == false)
            {
                TrueOrFalse = true;
            }

            return TrueOrFalse;
        }
        public static bool StreetSuffix(string userInput)
        {
            bool TrueOrFalse = false;

            if (userInput == "Rd" | userInput == "St" | userInput == "Dr" | userInput == "Blvd" )
            {
                TrueOrFalse = true;
            }

            return TrueOrFalse;
        }
        public static bool State(string userInput)
        {
            bool TrueOrFalse = false;
            string[] compare = { "QLD", "NSW", "VIC", "TAS", "SA", "NT", "WA", "ACT"};

            foreach (string s in compare)
            {
                if (userInput == s)
                {
                    TrueOrFalse = true;
                }
            }

            return TrueOrFalse;
        }
        public static bool PostCode(string userInput)
        {
            bool TrueOrFalse = false;
            int a;
            if (String.IsNullOrWhiteSpace(userInput) == false & int.TryParse(userInput, out a) == true)
            {
                int userInputInt = int.Parse(userInput);

                if (userInputInt > 1000 & userInputInt < 9999)
                {
                    TrueOrFalse = true;
                }
            }

            return TrueOrFalse;
        }
    }
}
