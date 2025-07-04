using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class FirstSignIn
    {
        public static bool Check()
        {
            // Declare some variables
            bool TrueOrFalse = true;
            string fileName = @"UserAddress.txt";

            //Get relevent information for the method
            string[] data = Database.Retrieve(fileName); // Get data from UserAddress.txt
            List<string> userData = new List<string>(); 
            userData = UserManager.ListUse.GetData(); // Get current signed in user's username and email
            string email = userData[1]; // Get the signed in user's email
           
            // Search the data array for the signed in user's email.
            for (int i = 0; i < data.Length; i++)
            {
                // if signed in user's email is found in data, set value to false as this is not first sign in
                if (email == data[i]) { TrueOrFalse = false; } 
            }
            
            return TrueOrFalse;
        }
    }
}
