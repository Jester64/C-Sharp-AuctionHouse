using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class SignIn : Dialog
    {
        public override string Title => "Sign In";
        public override void Display()
        {
            //Display the header of the page
            ShowTitle(Title);

            // Declare soem values
            string[] data = Database.Retrieve(@"UserStore.txt");
            bool isPerson = false;
            int emailLocation = 0;
            string inputEmail = "";
            string inputPassword = "";

            // Until the user inputs a correct email and password pair, continue to loop.
            while (isPerson == false)
            {
                // Take user inputs
                Console.WriteLine("Please enter your email address");
                inputEmail = Console.ReadLine();

                Console.WriteLine("\nPlease enter your password");
                inputPassword = Console.ReadLine();

                // find the location of the inputed email
                for(int i = 0; i < data.Length; i++)
                {
                    if (data[i] == inputEmail) 
                    { 
                        emailLocation = i;
                    }
                }

                // If the email and password match, do something. Else, inform the user.
                if (data[emailLocation + 1] == inputPassword)
                {
                    isPerson = true;
                }
                else Console.WriteLine("Email or Password are incorrect. Please try again");
            }

            int usernameLocation = emailLocation - 1;
            string username = data[usernameLocation];
            Console.WriteLine(username);

            UserManager.ListUse.AddData(username ,inputEmail);

            //signInUser.Add(new SignInUser(inputEmail, inputPassword));
            ClientMenu menu = new ClientMenu();
            menu.Display();
        }
    }
}
