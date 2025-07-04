using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ValidateClientMenu
    {
        public static bool ClienMenu(string userInput)
        {
            bool TrueOrFalse = false;

            if (userInput == "1" | userInput == "2" | userInput == "3" | userInput == "4" | userInput == "5" | userInput == "6")
            {
                TrueOrFalse = true;
            }

            return TrueOrFalse;
        }
    }
}
