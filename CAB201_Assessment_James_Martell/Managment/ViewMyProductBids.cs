using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ViewMyProductBids : Dialog
    {
        public override string Title => "List Product Bids for";

        public override void Display()
        {
            //Collect signed in user's information
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            List<string> sendData = new List<string>();
            userData = UserManager.List2Use.GetData();

            string title = $"{Title} {userData[0]}({userData[1]})";
            ShowTitle(title);
            
            //Get all advertised products and thier related information
            string[] allProducts = Database.Retrieve("AdvertisedProducts.txt");

            //Get the user's Products and thier related information
            List<string> userProducts = new List<string>();
            for (int i = 0; i < allProducts.Length; i += 8)
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


            //Then remove the ones that don't have a bid on them
            bool entriesAdded = false;
            List<string> biddedOnProducts = new List<string>();
            for (int i = 5; i < userProductsArray.Length; i += 6)
            {
                //Console.WriteLine(userProductsArray[i]);
                if (userProductsArray[i] != "-")
                {
                    for (int j = i - 5; j < (i + 1); j++)
                    {
                        //Console.WriteLine(userProductsArray[j]);
                        biddedOnProducts.Add(userProductsArray[j]);
                    }
                    entriesAdded = true;
                }
            }

            int count = 0; // keep track of the number of entries each line.
            int IDNumber = 1; // keep track of the number of products.

            if (entriesAdded == false) { Console.WriteLine(""); }
            else
            {
                //Sort the Bidded on products in asceding order
                List<string> sortedBiddedOnProducts = SortArray.Ascending(biddedOnProducts);

                Console.WriteLine("Item #\tProduct name\tDescription\tListPrice\tBidder name\tBidder email\tBid amt");


                //Display the users product they have put up
                for (int i = 0; i < sortedBiddedOnProducts.Count; i++)
                {
                    //Display the id number of the product
                    if (count == 0)
                    {
                        Console.Write($"{IDNumber}\t");
                        IDNumber++;
                        count++;
                    }

                    // print each product and thier details
                    Console.Write($"{sortedBiddedOnProducts[i]}\t");
                    count++;

                    // when 7 entries are displayed, create a new line and reset the count
                    if (count == 7)
                    {
                        Console.Write("\n");
                        count = 0;
                    }
                }


                bool isValid = false;
                string isSell = "";
                while (isValid == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Would you like to sell something (yes or no)?");
                    Console.Write(">");
                    isSell = Console.ReadLine();
                    Console.WriteLine("");
                    if (isSell == "no")
                    {
                        isValid = true;
                        ClientMenu run = new ClientMenu();
                        run.Display();
                    }
                    else if (isSell == "yes")
                    {
                        isValid = false;
                        string userInput = "";
                        int userInt;
                        while (isValid == false)
                        {
                            Console.WriteLine($"Please enter an intiger between 1 and {IDNumber - 1}");
                            Console.Write(">");
                            userInput = Console.ReadLine();
                            Console.WriteLine("");
                            if (int.TryParse(userInput, out userInt) == true && userInt <= IDNumber - 1 && userInt >= 1)
                            {
                                int productNameLocation = (6 * (userInt - 1));
                                string[] productToSell = { "0", "1", "2", "3", "4", "5" };
                                productToSell[0] = sortedBiddedOnProducts[productNameLocation];     //Add p name
                                productToSell[1] = sortedBiddedOnProducts[productNameLocation + 1]; //Add p Description
                                productToSell[2] = sortedBiddedOnProducts[productNameLocation + 2]; //Add p price
                                productToSell[3] = sortedBiddedOnProducts[productNameLocation + 3]; //Add b name
                                productToSell[4] = sortedBiddedOnProducts[productNameLocation + 4]; //Add b email
                                productToSell[5] = sortedBiddedOnProducts[productNameLocation + 5]; //Add b bidamt

                                List <string> productToSellList = productToSell.ToList();
                                foreach (string s in productToSellList)
                                {
                                    Console.WriteLine(s);
                                }

                                List<string> buyInfo = new List<string>();
                                //info checklist for bought products
                                buyInfo.Add(userData[1]);
                                buyInfo.Add(sortedBiddedOnProducts[productNameLocation]);
                                buyInfo.Add(sortedBiddedOnProducts[productNameLocation + 1]);
                                buyInfo.Add(sortedBiddedOnProducts[productNameLocation + 2]);
                                buyInfo.Add(sortedBiddedOnProducts[productNameLocation + 5]);
                                buyInfo.Add(sendData[0]);

                                Database.Add(buyInfo, "SoldProducts.txt");

                                SellProduct.Sell(productToSellList);
                                isValid = true;
                            }
                        }
                    }
                }
            }
        }
    }
}
