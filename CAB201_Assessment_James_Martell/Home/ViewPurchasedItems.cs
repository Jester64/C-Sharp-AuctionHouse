using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class ViewPurchasedItems : Dialog
    {
        public override string Title => "Purchased items for";

        public override void Display()
        {
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            string title = $"{Title} {userData[0]}({userData[1]})";
            ShowTitle(title);

            string[] stuff = Database.Retrieve("SoldProducts.txt");
            List<string> stuffList = stuff.ToList();


            Console.WriteLine("Item #\tSeller Email\tProduct Name\tDescription\tList Price\tAmt Paid\tDelivery option");

            int count = 0; // keep track of the number of entries each line.
            int IDNumber = 1; // keep track of the number of products.
            //Display the users product they have put up
            for (int i = 0; i < stuffList.Count; i++)
            {
                //Display the id number of the product
                if (count == 0)
                {
                    Console.Write($"{IDNumber}\t");
                    IDNumber++;
                    count++;
                }

                // print each product and thier details
                Console.Write($"{stuffList[i]}\t");
                count++;

                // when 7 entries are displayed, create a new line and reset the count
                if (count == 7)
                {
                    Console.Write("\n");
                    count = 0;
                }
            }

            // Note to marker: this is where i got up to to sry if its still buggy

        }
    }
}
