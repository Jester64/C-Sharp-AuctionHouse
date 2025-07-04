using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AuctionHouse
{
    internal class SearchDataManagement
    {
        public static List<string> Manage(string searchPhrase)
        {
            //Collect signed in user's information
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            //Get products from AdvertisedProducts.txt databse
            string[] storeProducts = Database.Retrieve("AdvertisedProducts.txt");

            //Get all store product that the user has not put in themselfes
            List<string> notUserProducts = new List<string>();
            for (int i = 0; i < storeProducts.Length; i += 8)
            {
                if (storeProducts[i] != userData[1])
                {
                    for (int j = i + 1; j < (i + 7); j++)
                    {
                        notUserProducts.Add(storeProducts[j]);
                    }
                }
            }
            string[] storeProductsArray = notUserProducts.ToArray(); // convert the list to an array

            if (searchPhrase != "ALL")
            {
                // Seach store product's name and description for search phrase
                List<string> searchedProducts = new List<string>();
                int count = 0;
                for (int i = 0; i < storeProductsArray.Length; i += 6) //cycle through all product names
                {
                    if (Regex.IsMatch(storeProductsArray[i], $"{searchPhrase}")) // if the search phrase matches the title
                    {
                        // add the product and it info to searched for products
                        for (int j = i; j < (i + 6); j++)
                        {
                            searchedProducts.Add(storeProductsArray[j]);
                        }
                        count = 1;
                    }
                    else if (Regex.IsMatch(storeProductsArray[i + 1], $"{searchPhrase}")) // if the desciption matches the search phrase and 
                    {                                                                     // and the product name doesn't
                        Console.WriteLine(storeProductsArray[i + 1]);
                        // add the product and it info to searched for products
                        for (int j = i - 1; j < (i + 6); j++)
                        {
                            searchedProducts.Add(storeProductsArray[j]);
                        }
                        count = 1;
                    }
                }
                if (count == 0) { return null; }
                else { return searchedProducts; }
            }
            else
            {
                return notUserProducts;
            }
        }
    }
}
