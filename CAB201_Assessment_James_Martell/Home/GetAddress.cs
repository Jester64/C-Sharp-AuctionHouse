using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class GetAddress
    {
        
        public static List<string> Display(bool useDatabse)
        {
            // Get the signed in user's usernmae and email
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            string[] prompts = { "UnitNumber", "StreetNumber", "StreetName", "StreetSuffix", "City", "Postcode", "State"};

            // Prompt the user to input thier address information
            Console.WriteLine("Please provide your home address.");

            // Declare values to be put in the database
            List<string> userInformation = new List<string>();
            userInformation.Add(userData[1]);       // add the users email for later idetification
            string inputUnitNumber = "";
            string inputStreetNumber = "";
            string inputStreetName = "";
            string inputStreetSuffix = "";
            string inputCity = "";
            string inputState = "";
            string inputPostcode = "";

            foreach (string prompt in prompts)
            {
                bool isValid = false;
                while (isValid == false) // While the user's inputs are not valid, continue to ask for an input
                {
                    switch (prompt)
                    {
                        case "UnitNumber":    // Ask for the user's Unit Number
                            Console.WriteLine("Unit number (0 = none):");
                            Console.Write(">");
                            inputUnitNumber = Console.ReadLine();
                            if (inputUnitNumber == "0")                 // If input is 0, change input to "none"
                            {
                                inputUnitNumber = "none";
                                isValid = true;
                            }
                            else
                            {
                                isValid = ValidateGetAddress.UnitNumber(inputUnitNumber);
                            }
                            if (isValid == false) { Console.WriteLine("\tUnit number must be a non-negitive integer."); }
                            Console.WriteLine("");
                            break;

                        case "StreetNumber":  // Ask for the user's Street Number
                            Console.WriteLine("Street number:");
                            Console.Write(">");
                            inputStreetNumber = Console.ReadLine();
                            isValid = ValidateGetAddress.StreetNumber(inputStreetNumber);
                            if (isValid == false) { Console.WriteLine("\tSteet number must be a non-negitive integer."); }
                            Console.WriteLine("");
                            break;

                        case "StreetName": // Ask for the user's Street Name
                            Console.WriteLine("Street name:");
                            Console.Write(">");
                            inputStreetName = Console.ReadLine();
                            isValid = ValidateGetAddress.StreetNameAndCity(inputStreetName);
                            Console.WriteLine("");
                            break;

                        case "StreetSuffix": // Ask for the user's Street Suffix
                            Console.WriteLine("Street suffix:");
                            Console.Write(">");
                            inputStreetSuffix = Console.ReadLine();
                            isValid = ValidateGetAddress.StreetSuffix(inputStreetSuffix);
                            Console.WriteLine("");
                            break;

                        case "City":  // Ask for the user's City
                            Console.WriteLine("City:");
                            Console.Write(">");
                            inputCity = Console.ReadLine();
                            isValid = ValidateGetAddress.StreetNameAndCity(inputCity);
                            Console.WriteLine("");
                            break;

                        case "State": // Ask for the user's State/Teritory
                            Console.WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                            Console.Write(">");
                            inputState = Console.ReadLine();
                            isValid = ValidateGetAddress.State(inputState);
                            Console.WriteLine("");
                            break;

                        case "Postcode": // Ask for the user's Postcode
                            Console.WriteLine("Postcode (1000 .. 9999):");
                            Console.Write(">");
                            inputPostcode = Console.ReadLine();
                            isValid = ValidateGetAddress.PostCode(inputPostcode);
                            Console.WriteLine("");
                            break;
                    }
                }
            }
            // Add all collected data to a list
            userInformation.Add(inputUnitNumber);
            userInformation.Add(inputStreetNumber);
            userInformation.Add(inputStreetName);
            userInformation.Add(inputStreetSuffix);
            userInformation.Add(inputCity);
            userInformation.Add(inputState);
            userInformation.Add(inputPostcode);

            if (useDatabse == true)
            {
                //Add all collected information to the UserAddress.txt database.
                Database.Add(userInformation, "UserAddress.txt");
            }

            return userInformation;
        }
    }
}
