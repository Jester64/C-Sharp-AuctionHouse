using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class DeliveryInstructions : Dialog
    {
        public override string Title => "Delivery Instructions";

        public override void Display()
        {
            // Collect signed in user's information
            List<string> userData = new List<string>();
            userData = UserManager.ListUse.GetData();

            // Get the current time date
            DateTime now = DateTime.Now;

            //disply the page title and options
            Console.WriteLine("Delivery Instructions");
            Console.WriteLine("---------------------");
            Console.WriteLine("(1) Click and collect");
            Console.WriteLine("(2) Home Delivery");
            Console.WriteLine("");

            bool isValid = false;
            string userInput = "";
            while (isValid == false)
            {
                Console.WriteLine("Please select an option between 1 and 2");
                Console.Write(">");
                userInput = Console.ReadLine();
                Console.WriteLine("");
                if (userInput == "1" | userInput == "2") { isValid = true; }
            }

            // list for if the user selects clickncollect
            List<string> ClickNCollect = new List<string>();

            // lict for if the user selects home delivery
            List<string> userAddressInfo = new List<string>();

            if (userInput == "1")
            {
                string startTime = "";
                DateTime startDateTime = DateTime.Now;
                isValid = false;
                while (isValid == false)
                {
                    Console.WriteLine("Delivery window start (dd/mm/yyyy hh:mm)");
                    Console.Write(">");
                    startTime = Console.ReadLine();
                    TimeSpan time = new TimeSpan(0, 1, 0, 0);
                    DateTime nowInHour = now.Add(time);
                    if (DateTime.TryParse(startTime, out startDateTime) == true)
                    {
                        if (startDateTime.TimeOfDay > nowInHour.TimeOfDay && startDateTime.Date >= nowInHour.Date)
                        {
                            isValid = true;
                        }
                        else { Console.WriteLine("\tDelivery window start must be at least on hour in the futrue"); }
                    }
                    Console.WriteLine("");
                }

                // calculate the start time plus one hour to get the minimum end time
                TimeSpan hourIncrease = new TimeSpan(0, 1, 0, 0);
                DateTime expectedEndTime = startDateTime.Add(hourIncrease);

                DateTime endDateTime = DateTime.Now;
                isValid = false;
                while (isValid == false)
                {
                    Console.WriteLine("Delivery window end (dd/mm/yyyy hh:mm)");
                    Console.Write(">");
                    userInput = Console.ReadLine();
                    if (DateTime.TryParse(userInput, out endDateTime) == true)
                    {
                        if (endDateTime.TimeOfDay > expectedEndTime.TimeOfDay && endDateTime.Date >= expectedEndTime.Date)
                        {
                            isValid = true;
                        }
                        else { Console.WriteLine("\tDelivery window end must be at least one hourlater than the start"); }
                    }
                    Console.WriteLine("");
                }

                ClickNCollect.Add(startDateTime.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));
                ClickNCollect.Add(endDateTime.ToString("yyyy-MM-ddTHH:mm:ss.ffffffK"));

                Console.WriteLine($"Thank you for your bid. If successful, the item will be provided via collection between " +
                    $"{startDateTime.ToString("HH:mm")} on {startDateTime.ToString("dd-mm-yyy")} and {endDateTime.ToString("HH:mm")} on " +
                    $"{endDateTime.ToString("dd-mm-yyy")}");

                string entry = $"Click and collect between {startDateTime.ToString("HH:mm")} on {startDateTime.ToString("dd-mm-yyy")} and {endDateTime.ToString("HH:mm")} on " +
                    $"{endDateTime.ToString("dd-mm-yyy")}";
                UserManager.List2Use.AddData(entry);
            }

            
            else if (userInput == "2")
            {
                userAddressInfo = GetAddress.Display(false);

                Console.WriteLine($"Thank you for your bid. If successful, the item will be provided via delivery 10 {userAddressInfo[1]}/{userAddressInfo[2]} " +
                    $"{userAddressInfo[3]} {userAddressInfo[4]}, {userAddressInfo[5]} {userAddressInfo[6]} {userAddressInfo[7]}");

                string entry = $" Deliver to {userAddressInfo[1]}/{userAddressInfo[2]} " +
                    $"{userAddressInfo[3]} {userAddressInfo[4]}, {userAddressInfo[5]} {userAddressInfo[6]} {userAddressInfo[7]}";

                UserManager.List2Use.AddData(entry);
            }

            ClientMenu run = new ClientMenu();
            run.Display();

        }
    }
}
