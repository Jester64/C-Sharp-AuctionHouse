using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuctionHouse
{
    class MainMenu : Dialog
    {
        public override string Title => "Main Menu";
        public override void Display()
        {
            
            //Display the home intrface and provide options to the user
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Welcome to the Auction House |");
            Console.WriteLine("+------------------------------+");

            ShowTitle(Title);
            Console.WriteLine("(1) Resgister");
            Console.WriteLine("(2) Sign In");
            Console.WriteLine("(3) Exit \n");

            //Declare same values to be used in user input and the actions that should come after
            bool isValid = false;
            string userInput = "Nothing";

            //Continue to ask the user for inputs untill they provide an expected answer
            while (isValid == false)
            {
                Console.WriteLine("Please select an option between 1 and 3");
                inputType Type = inputType.Main;
                Console.Write(">");
                userInput = Console.ReadLine();

                isValid = Authenticate.InputValidation(userInput, Type);
            }

            //Depending on input display a page to the user 
            if (userInput == "1")
            {
                Register register = new Register();
                register.Display();
            }
            else if (userInput == "2")
            {
                SignIn signIn = new SignIn();
                signIn.Display();
            }
            else if (userInput == "3")
            {
                

            }
        }
    }
}
