using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    // try char.IsLetterOrDigit when trying to detect symbols for the passoword.
    public enum inputType
    {
        Void, Main, Name, Email, Password, Repeat
    }
    class Authenticate
    {
        public static bool InputValidation(string userInput, inputType inputType)
        {
            //Return value to allow the program to continue
            bool TrueOrFalse = false;

            //Validate the Main Menu input
            switch (inputType)
            {
                case inputType.Main:
                    if (userInput == "1" | userInput == "2" | userInput == "3")
                    {
                        TrueOrFalse = true;
                    }
                    break;
                case inputType.Name:
                    if (String.IsNullOrEmpty(userInput) == false && String.IsNullOrWhiteSpace(userInput) == false)
                    {
                        TrueOrFalse = true;
                    }
                    break;
                case inputType.Email:
                    if (String.IsNullOrEmpty(userInput) == false && String.IsNullOrWhiteSpace(userInput) == false)
                    {
                        string[] splitUserInput = userInput.Split("@", 2, StringSplitOptions.RemoveEmptyEntries); //Split user input to evaluate the characters before the '@' and after it
                        int splitLocation = userInput.IndexOf('@'); //Find the location of the first '@'

                        //Prefix information
                        int underscoreLocation = splitUserInput[0].IndexOf('_', splitUserInput[0].Length - 1); //Find the last location of the unserscore in the prefix
                        int dashLocation = splitUserInput[0].IndexOf('-', splitUserInput[0].Length - 1); // Find the last location of the dash in the prefix
                        int periodLocation = splitUserInput[0].IndexOf('.', splitUserInput[0].Length - 1); //Find the location of the last period
                        bool firstCharLimit = Regex.IsMatch(splitUserInput[0], @"[a-zA-Z0-9_.-]+$"); //Check if the characters before the '@' are letters numbers and '.', '-', and '_'. if they are not return false.
                        if (splitLocation != -1)
                        {
                            //Suffix information
                            bool lastCharLimit = Regex.IsMatch(splitUserInput[1], @"[a-zA-Z0-9.-]+$");
                            int periodCheck = splitUserInput[1].IndexOf('.');

                            if (splitLocation != -1 & splitLocation != 0 & splitLocation != userInput.Length - 1
                                & firstCharLimit == true & underscoreLocation != splitUserInput[0].Length - 1 &
                                dashLocation != splitUserInput[0].Length - 1 & periodLocation != splitUserInput[0].Length - 1
                                & lastCharLimit == true & periodCheck != -1 & periodCheck != 0 & periodCheck != splitUserInput[1].Length - 1)
                            {
                                TrueOrFalse = true;
                            }
                        }
                    }
                    break;
                case inputType.Password:
                    if (userInput.Length > 7 & userInput.Any(x => Char.IsWhiteSpace(x)) == false)
                    {
                        //bool hasAllowedCharacters = Regex.IsMatch(userInput, @"[A-Za-z0-9]+$");
                        bool hasSymbol = false;
                        bool hasUpper = false;
                        bool hasLower = false;
                        bool hasDigit = false;
                        foreach (char c in userInput)
                        {
                            if (Char.IsUpper(c)) { hasUpper = true; }
                            if (Char.IsLower(c)) { hasLower = true; }
                            if (Char.IsDigit(c)) { hasDigit = true; }
                            if (!(Char.IsLetterOrDigit(c)) == true) { hasSymbol = true; }
                        }
                        if (hasUpper == true && hasLower == true && hasDigit == true && hasSymbol == true)
                        {
                            TrueOrFalse = true;
                        }                                                                                
                    }
                    break;
            }
            return TrueOrFalse;
        }
    }
}

