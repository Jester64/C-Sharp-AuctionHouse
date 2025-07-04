using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class SortArray
    {
        public static List<string> Ascending(List<string> userProducts)
        {
            List<string> priceHolder = new List<string>();
            //Sort each product and their info by name, description then price in ascending order
            //First sort by price
            //Take all the prices and put them in a list
            for (int i = 2; i < userProducts.Count; i += 6)
            {
                priceHolder.Add(userProducts[i]);
            }
            string[] priceHolderArr = priceHolder.ToArray();    // convert this list to an array
            Array.Sort(priceHolderArr);     // sort the array in ascending order

            //seach through all the data and add a product to the sorted list using the sorted list when to add a specific product
            List<string> SortedByPrice = new List<string>();
            foreach (string price in priceHolderArr)
            {
                for (int i = 2; i < userProducts.Count; i+=6) // specifically look at where all descriptions are located
                {
                    if (price == userProducts[i])       // if a match is found
                    {
                        SortedByPrice.Add(userProducts[i - 2]);
                        SortedByPrice.Add(userProducts[i - 1]);
                        SortedByPrice.Add(userProducts[i]);         // add all relevent data
                        SortedByPrice.Add(userProducts[i + 1]);
                        SortedByPrice.Add(userProducts[i + 2]);
                        SortedByPrice.Add(userProducts[i + 3]);

                        userProducts[i - 2] = "";
                        userProducts[i - 1] = "";
                        userProducts[i] = "";                       // remove data from old list to prevent multiple entries of the same data
                        userProducts[i + 1] = "";                   // in the new sorted list
                        userProducts[i + 2] = "";
                        userProducts[i + 3] = "";


                        break;
                    }
                }
            }
            
            // Then sort by description
            // Take all desciptions and put them in a list
            List<string> descHolder = new List<string>();
            for (int i = 1; i < SortedByPrice.Count; i += 6)
            {
                descHolder.Add(SortedByPrice[i]);
            }
            string[] descHolderArr = descHolder.ToArray(); // convert this list to an array
            Array.Sort(descHolderArr);  // sort the array in ascending order


            List<string> SortedByDesc = new List<string>();
            foreach (string desc in descHolderArr)
            {
                for (int i = 1; i < SortedByPrice.Count; i += 6)
                {
                    if (desc == SortedByPrice[i])
                    {
                        SortedByDesc.Add(SortedByPrice[i - 1]);
                        SortedByDesc.Add(SortedByPrice[i]);
                        SortedByDesc.Add(SortedByPrice[i + 1]);
                        SortedByDesc.Add(SortedByPrice[i + 2]);
                        SortedByDesc.Add(SortedByPrice[i + 3]);
                        SortedByDesc.Add(SortedByPrice[i + 4]);

                        SortedByPrice[i - 1] = "";
                        SortedByPrice[i] = "";
                        SortedByPrice[i + 1] = "";
                        SortedByPrice[i + 2] = "";
                        SortedByPrice[i + 3] = "";
                        SortedByPrice[i + 4] = "";

                        break;
                    }
                }
            }

            // Lastly, sort through the names
            List<string> nameHolder = new List<string>();
            for (int i = 0; i < SortedByDesc.Count; i += 6)
            {
                nameHolder.Add(SortedByDesc[i]);
            }
            string[] nameHolderArr = nameHolder.ToArray(); // convert this list to an array
            Array.Sort(nameHolderArr);  // sort the array in ascending order

            List<string> SortedByName = new List<string>();
            foreach (string name in nameHolderArr)
            {
                for (int i = 0; i < SortedByDesc.Count; i += 6)
                {
                    if (name == SortedByDesc[i])
                    {
                        SortedByName.Add(SortedByDesc[i]);
                        SortedByName.Add(SortedByDesc[i + 1]);
                        SortedByName.Add(SortedByDesc[i + 2]);
                        SortedByName.Add(SortedByDesc[i + 3]);
                        SortedByName.Add(SortedByDesc[i + 4]);
                        SortedByName.Add(SortedByDesc[i + 5]);

                        SortedByDesc[i] = "";
                        SortedByDesc[i + 1] = "";
                        SortedByDesc[i + 2] = "";
                        SortedByDesc[i + 3] = "";
                        SortedByDesc[i + 4] = "";
                        SortedByDesc[i + 5] = "";

                        break;
                    }
                }
            }

            return SortedByName;
        }
    }
}
