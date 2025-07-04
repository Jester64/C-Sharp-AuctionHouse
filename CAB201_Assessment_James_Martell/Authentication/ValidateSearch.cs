using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ValidateSearch
    {
        public static bool SelectNumber(string userInput, int maxRange)
        {
            bool TrueOrFalse = false;
            int intOut;
            if (int.TryParse(userInput, out intOut) == true && intOut >= 1 && intOut <= maxRange)
            {
                TrueOrFalse = true;
            }

            return TrueOrFalse;
        }

        public static bool Bid(string userInput, string currentBid)
        {
            bool TrueOrFalse = false;

            bool isPriceValid = ValidateAdvertiseProduct.Price(userInput); // copy code used to validate apendix 1, case 7 input validation
            
            int bidInt;
            if (isPriceValid == true)
            {
                userInput = userInput.Replace("$", "");
                userInput = userInput.Replace(".", "");
                // set up inputs to be made ints
                currentBid = currentBid.Replace("$", "");
                currentBid = currentBid.Replace(".", "");

                int userInputInt = int.Parse(userInput);    // make inputs ints to be compared
                int currentBidInt = int.Parse(currentBid);

                if (userInputInt > currentBidInt) { TrueOrFalse = true; } // if the user bid is greater than the current bid, allow the 
            }

            return TrueOrFalse;
        }
    }
}
