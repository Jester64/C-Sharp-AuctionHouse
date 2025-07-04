using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class SellProduct
    {
        public static void Sell(List<string> productToSell)
        {
            // Get all advertised products
            string[] allproducts = Database.Retrieve("AdvertisedProducts.txt");
            List<string> allProductsList = allproducts.ToList();


            for (int i = 1; i < allProductsList.Count; i += 8)
            {
                //Console.WriteLine(allProductsList[i]);
                if (allProductsList[i] == productToSell[0]&&
                    allProductsList[i + 1] == productToSell[1] &&       // check to see if the product's name, desc and price match the item's to sell
                    allProductsList[i + 2] == productToSell[2])
                {
                    for (int j = i - 1; j < (i + 7); j++) // Remove the product from the auction house
                    {
                        allProductsList.RemoveAt(i - 1);
                        
                    }
                }
            }

            string[] allProductsArr = allProductsList.ToArray();
            foreach (string s in allProductsArr)
            {
                Console.WriteLine(s);
            }

            Database.Edit("AdvertisedProducts.txt", allProductsArr, 8);
            
        }
    }
}
