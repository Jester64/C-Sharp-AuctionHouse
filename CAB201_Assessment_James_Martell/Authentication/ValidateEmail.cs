using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    class ValidateEmail
    {
        public static bool IsRepeat(string userInput, string fileName)
        {

            string[] data = Database.Retrieve(fileName);
            bool repeat = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (userInput == data[i]) { repeat = true; }
            }
            return repeat;
        }                                                                                               //Keeping just in case

        //public static List<string> Search(string userInput, string fileName) //First try of a search function
        //{
        //    string[] data = Database.Retrieve(fileName);
        //    List<string> matches = new List<string>();
            
        //    for (int i = 0; i <= data.Length - 1; i++) // i value used to access each entry in the database (data array)
        //    {
        //        // declare values to help identify matches
        //        int matchCount = 0;
        //        bool isMatch = false;
        //        for (int j = 0; j <= userInput.Length - 1; j++) // j value used to access each character of the userInput value
        //        {
        //            for (int k = 0; k <= data[i].Length - 1; k++) // k value used to access each character in an entry
        //            {
        //                if (data[i][k] == userInput[j])
        //                {
        //                    matchCount++;
        //                    if (matchCount == userInput.Length)
        //                    {
        //                        isMatch = true;
        //                    }
        //                    if (j != userInput.Length - 1) { j++; }
        //                }
        //                else { matchCount = 0; }
        //            }
        //        }
        //        if (isMatch == true)
        //        {
        //            matches.Add(data[i]);
        //        }
        //    }
        //    return matches;
        //}

        public static List<string> Search(string userInput, string fileName)
        {
            //This code works with the below function
            Console.WriteLine("Seach Test: enter a phrase and the response should show all database entries that share the phrase");
            string funny = Console.ReadLine();
            List<string> display = new List<string>();
            display = ValidateEmail.Search(funny, fileName);
            foreach (string displayItem in display) { Console.WriteLine(displayItem); }

            //declare some variables 
            string[] data = Database.Retrieve(fileName);
            List<string> matches = new List<string>();
            bool isMatch = false;
            
            // Check each entry in the database for the asme phrase the user inputed
            for (int i = 0; i <= data.Length - 1; i++)
            {
                if (Regex.IsMatch(data[i], $"{userInput}"))
                {
                    matches.Add(data[i]);
                }
            }
            // retuen all matching results
            return matches;
        }
    }
}
