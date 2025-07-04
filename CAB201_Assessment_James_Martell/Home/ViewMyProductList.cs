using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ViewMyProductList : Dialog
    {
        public override string Title => "Product List for";

        public override void Display()
        {
            // Get the signed in user's usernmae and email
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            //Show the title for the page
            string title = $"{Title} {userData[0]}({userData[1]})";
            ShowTitle(title);

            //Get all advertised products and thier related information
            string[] allProducts = Database.Retrieve("AdvertisedProducts.txt");

            //Get the user's Products and thier related information
            List<string> userProducts = new List<string>();
            for (int i = 0; i < allProducts.Length; i+=8)
            {
                if (allProducts[i] == userData[1])
                {
                    for (int j = i + 1; j < (i + 7); j++)
                    {
                        userProducts.Add(allProducts[j]);
                    }
                }
            }
            string[] userProductsArray = userProducts.ToArray(); // convert the list to an array

            // check whether the signed in user has anything in thier products list
            bool hasEntries = false;
            foreach (string s in allProducts)
            {
                if (s == userData[1]) { hasEntries = true; }
            }

            // if not then run this
            if (hasEntries == false) { Console.Write("You have no advertised products at the moment"); } // come back here later
            else //if they do then run this
            {

                List<string> sortedUserProducts = SortArray.Ascending(userProducts);

                Console.WriteLine("Item #\tProduct name\tDescription\tListPrice\tBidder name\tBidder email\tBid amt");
                int count = 0; // keep track of the number of entries each line.
                int IDNumber = 1; // keep track of the number of products.

                //Display the users product they have put up
                for(int i = 0; i < sortedUserProducts.Count; i++)
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
                    if(count == 7)
                    {
                        Console.Write("\n");
                        count = 0;
                    }
                }

                // take the user back to the client menu page
                ClientMenu menu = new ClientMenu();
                menu.Display();
            }
        }
    }
}
