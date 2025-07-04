using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    internal class Search : Dialog
    {
        public override string Title => "Product Search for";
        public override void Display()
        {
            //Collect signed in user's information
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            // Display title of page
            string title = $"{Title} {userData[0]}({userData[1]})";
            ShowTitle(title);

            // prompt for the user to search products
            bool isValid = false;
            string searchPhrase = "";
            while (isValid == false)
            {
                Console.WriteLine("Please supply a search phrase (ALL to see all products)");
                Console.Write(">");
                searchPhrase = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(searchPhrase) == false) { isValid = true; }
                Console.WriteLine("");
            }

            // get store data and cut out the signed in user's products. if the user enters "ALL", show all product. else return products
            // whos names and descriptions match the search phrase
            List<string> products = SearchDataManagement.Manage(searchPhrase);
            bool empty = false;
            //foreach(string product in products)
            //{
            //if (String.IsNullOrWhiteSpace(products[0]) == true) { empty = true; }
            if (products == null) { empty = true; }
            //}
            int count = 0; // keep track of the number of entries each line.
            int IDNumber = 1; // keep track of the number of products.
            if (empty == true)
            {
                Console.WriteLine(""); // come back here later
                ClientMenu run = new ClientMenu();
                run.Display();
            }
            else //else. display the products
            {
                List<string> sortedUserProducts = SortArray.Ascending(products);

                Console.WriteLine("Item #\tProduct name\tDescription\tListPrice\tBidder name\tBidder email\tBid amt");


                //Display the users product they have put up
                for (int i = 0; i < sortedUserProducts.Count; i++)
                {
                    //Display the id number of the product
                    if (count == 0)
                    {
                        Console.Write($"{IDNumber}\t");
                        IDNumber++;
                        count++;
                    }

                    // print each product and thier details
                    Console.Write($"{sortedUserProducts[i]}\t");
                    count++;

                    // when 7 entries are displayed, create a new line and reset the count
                    if (count == 7)
                    {
                        Console.Write("\n");
                        count = 0;
                    }
                }
            }

            // prompt for the user to place a bid or not to
            isValid = false;
            while (isValid == false)
            {
                Console.WriteLine("Would you like to place a bid on any of these items (yes or no)");
                Console.Write(">");
                string yesOrNO = Console.ReadLine();
                Console.WriteLine("");
                if (yesOrNO == "yes")
                {
                    isValid = true;
                }
                if (yesOrNO == "no")
                {
                    isValid = true;
                    ClientMenu run = new ClientMenu();
                    run.Display();
                }
            }

            isValid = false;
            string productSelect = "";
            while (isValid == false)
            {
                Console.WriteLine($"Please enter a non negitive number between 1 and {IDNumber - 1}");
                Console.Write(">");
                productSelect = Console.ReadLine();
                isValid = ValidateSearch.SelectNumber(productSelect, IDNumber - 1);
                Console.WriteLine("");
            }

            // Get auction house product data under user specifications
            List<string> AuctionHouseData = SearchDataManagement.Manage(searchPhrase);
            List<string> SortedAuctionHouseData = SortArray.Ascending(AuctionHouseData);

            // get the selection number to search for product info and find the row that contains the selected data
            int productNumber;
            bool Unrequired = int.TryParse(productSelect, out productNumber);
            int productNameLocation = 6 * (productNumber - 1);
            int listPriceLocation = 2 + (6 * (productNumber - 1));
            int currentBidLocation = 5 + (6 * (productNumber - 1));

            string bidAmt;
            if (SortedAuctionHouseData[currentBidLocation] == "-") { bidAmt = "$0.00"; }
            else { bidAmt = SortedAuctionHouseData[currentBidLocation].ToString(); }


            Console.WriteLine($"Bidding for {SortedAuctionHouseData[productNameLocation]}(regular price " +
                $"{SortedAuctionHouseData[listPriceLocation]}), current highest bid {bidAmt}");

            isValid = false;
            string userInput = "";
            while (isValid == false)
            {
                Console.WriteLine("How much do you bid?");
                Console.Write(">");
                userInput = Console.ReadLine();
                isValid = ValidateSearch.Bid(userInput, bidAmt);
                Console.WriteLine("");
                //isValid = ValidateSearch.Bid(userInput, bidAmt);
            }

            // get data in the same format that was used in ealier display
            List<string> productsToEdit = SearchDataManagement.Manage(searchPhrase);
            List<string> sortedProductsToEdit = SortArray.Ascending(productsToEdit);

            //get Auction house database
            string[] auctionHouseData = Database.Retrieve("AdvertisedProducts.txt");

            // get data location that need to be edited
            int bidderNameLocation = 3 + (6 * (productNumber - 1));
            int bidderEmailLocation = 4 + (6 * (productNumber - 1));
            currentBidLocation = currentBidLocation;

            // Create a new entry with the relevnt info 
            string[] editedproduct = { "0", "1", "2", "3", "4", "5" };
            editedproduct[0] = SortedAuctionHouseData[productNameLocation];     //Add name
            editedproduct[1] = SortedAuctionHouseData[productNameLocation + 1]; //Add Description
            editedproduct[2] = SortedAuctionHouseData[productNameLocation + 2]; //Add price
            editedproduct[3] = userData[0]; //Add Bidder name
            editedproduct[4] = userData[1]; //Add Bidder Email
            editedproduct[5] = userInput; //Add new bid amount

          

            // replace new entry with new entry
            for (int i = 1; i < auctionHouseData.Length; i += 8) // search through auction house data
            {
                if (auctionHouseData[i] == editedproduct[0] && auctionHouseData[i + 1] == editedproduct[1] 
                    && auctionHouseData[i + 2] == editedproduct[2])
                {
                    auctionHouseData[i + 3] = editedproduct[3];
                    auctionHouseData[i + 4] = editedproduct[4];
                    auctionHouseData[i + 5] = editedproduct[5];
                }
            }

            Database.Edit("AdvertisedProducts.txt", auctionHouseData, 8);

            Console.WriteLine($"Your bid {userInput} for {bidAmt} is placed\n");

            DeliveryInstructions display = new DeliveryInstructions();
            display.Display();
        }                                                   
    }
}
