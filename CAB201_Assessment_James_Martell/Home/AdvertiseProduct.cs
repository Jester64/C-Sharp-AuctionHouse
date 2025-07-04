using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class AdvertiseProduct : Dialog
    {
        public override string Title => "Product Advertisement for";

        public override void Display()
        {
            //Collect signed in user's information
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            //Display page title
            string title = $"{Title} {userData[0]}({userData[1]})";
            ShowTitle(title);

            //Set up prompts for user input
            string[] prompts = { "Product name", "Product description", "Product price ($d.cc)" };

            // declare values to store and trasnfer information
            List<string> userInformation = new List<string>();
            string inputName = "";
            string inputDescription = "";
            string inputPrice = "";

            foreach (string prompt in prompts)
            {
                bool isValid = false;
                while (isValid == false)
                {
                    switch (prompt)
                    {
                        case "Product name":
                            Console.WriteLine(prompt);
                            Console.Write(">");
                            inputName = Console.ReadLine();
                            isValid = ValidateAdvertiseProduct.Name(inputName);
                            Console.WriteLine("");
                            break;

                        case "Product description":
                            Console.WriteLine(prompt);
                            Console.Write(">");
                            inputDescription = Console.ReadLine();
                            isValid = ValidateAdvertiseProduct.Description(inputDescription, inputName);
                            Console.WriteLine("");
                            break;

                        case "Product price ($d.cc)":
                            Console.WriteLine(prompt);
                            Console.Write(">");
                            inputPrice = Console.ReadLine();
                            inputPrice = inputPrice.Replace(",", "");
                            isValid = ValidateAdvertiseProduct.Price(inputPrice);
                            if (isValid == false ) { Console.WriteLine("\tA currency is required, e.g. $ 54.95, $9.99, $2314.15"); }
                            Console.WriteLine("");
                            break;
                    }
                }
            }
            //find the number of entries to assign the new entry a ID number
            //string[] currentData = Database.Retrieve("AdvertisedProducts.txt");

            //string IDNumber = "";
            //if (currentData.Length == 0)
            //{                                                             Dont know if each thing needs a id number
            //    IDNumber = "1";
            //}
            //else
            //{
            //    int numberOfEntires = currentData.Length / 8;
            //    IDNumber = numberOfEntires.ToString();
            //}

            // place user inputs in list for trasport with email at the front for information identification
            //userInformation.Add(IDNumber);
            userInformation.Add(userData[1]);
            userInformation.Add(inputName);
            userInformation.Add(inputDescription);
            userInformation.Add(inputPrice);
            userInformation.Add("-");
            userInformation.Add("-");
            userInformation.Add("-");

            Database.Add(userInformation, "AdvertisedProducts.txt");
            Console.WriteLine($"Successfully added product {inputName}, {inputDescription}, {inputPrice}.");

            ClientMenu menu = new ClientMenu();
            menu.Display();
        }
    }
}
