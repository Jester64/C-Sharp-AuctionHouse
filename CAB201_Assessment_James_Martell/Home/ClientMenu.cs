using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ClientMenu : Dialog
    {
        public override string Title => "Client Menu";

        public override void Display()
        { 
            //Collect signed in user's information
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();
            
            bool isFirstSignIn = FirstSignIn.Check();
            if (isFirstSignIn == true)
            {
                string title = $"Personal Details for {userData[0]}({userData[1]})\n";
                ShowTitle(title);
                GetAddress.Display(true);
            }

            bool isValid = false; 
            string userInput = null;

            ShowTitle(Title);
            Console.WriteLine("(1) Advertise Product");
            Console.WriteLine("(2) View My Product List");
            Console.WriteLine("(3) Search For Advertised Products");
            Console.WriteLine("(4) View Bids On My Products");
            Console.WriteLine("(5) View My Purchased Items");
            Console.WriteLine("(6) Log off\n");

            // Keep requesting for a usrr input until a valid input is made
            while (isValid == false)
            {
                Console.WriteLine("Please select an option between 1 and 6");
                Console.Write(">");
                userInput = Console.ReadLine();
                isValid = ValidateClientMenu.ClienMenu(userInput);
            }

            if (userInput == "1" ){
                AdvertiseProduct run = new AdvertiseProduct();
                run.Display();
            }
            else if (userInput == "2")
            {
                ViewMyProductList run = new ViewMyProductList();
                run.Display();
            }
            else if (userInput == "3")
            {
                Search run = new Search();
                run.Display();
            }
            else if (userInput == "4")
            {
                ViewMyProductBids run = new ViewMyProductBids();
                run.Display();
            }
            else if (userInput == "5")
            {
                ViewPurchasedItems run = new ViewPurchasedItems();
                run.Display();
            }
            else if (userInput == "6")
            {
                // Sign out user and take them to the main menu
                UserManager.ListUse.ClearData();
                MainMenu menu = new MainMenu();
                menu.Display();
            }
        }
    }
}
