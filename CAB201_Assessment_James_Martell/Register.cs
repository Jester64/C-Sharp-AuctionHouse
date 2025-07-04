using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    class Register : Dialog
    {
        public override string Title => "Registration";
        public override void Display()
        {   
            //Display the header of the page
            ShowTitle(Title);

            //Declare values for user inputs
            string[] inputRequests = {"name", "email", "password" };
            string userInput = "";
            inputType Type = inputType.Void; 
            //string inputType = "";
            List<string> userInformation = new List<string>();
            string userName = null;
            string email = null;
            string fileName = @"UserStore.txt";

            //Cycle through each expected input untill all are inputted
            foreach (string prompt in inputRequests)
            {
                //Until the user provides an expected input, the program will continue to ask for an input
                bool isValid = false;
                bool isRepeat = false;
                while (isValid == false)
                {
                    if (prompt == "password")
                    {
                        Console.WriteLine("Please choose a password\n" +
                            "* At least 8 characters\n" +
                            "* No white space characters\n" +
                            "* At least on upper-case letter\n" +
                            "* At least one lower-case letter\n" +
                            "* At least 1 digit\n" +
                            "* At least 1 special character");
                        userInput = Console.ReadLine();
                        Console.WriteLine("");

                        Console.WriteLine(userInput.All(char.IsLetterOrDigit));
                        Type = inputType.Password;
                        isValid = Authenticate.InputValidation(userInput, Type);
                    }
                    else
                    {
                        //Ask the user for an input
                        Console.WriteLine($"Please enter your {prompt}");
                        userInput = Console.ReadLine();
                        Console.WriteLine("");

                        //Depending on the prompt, a input Type will be assigned to a user input for validation
                        if (prompt == "name") { Type = inputType.Name; userName = userInput; }
                        if (prompt == "email") { Type = inputType.Email; email = userInput; }

                        //Change the isValid value to true if the input is exceptable
                        isValid = Authenticate.InputValidation(userInput, Type);

                        isRepeat = ValidateEmail.IsRepeat(userInput, fileName);

                        if (isRepeat == true)
                        {
                            Console.WriteLine("The supplied address is already in use");

                        }
                    }
                }
                userInformation.Add(userInput);
            }
            Database.Add(userInformation, fileName);

            Console.WriteLine($"Client {userName}({email}) has successfully registered at the Auction House");

            //Takes the user back to the home page
            MainMenu menu = new MainMenu();
            menu.Display();
        }
    }
}
