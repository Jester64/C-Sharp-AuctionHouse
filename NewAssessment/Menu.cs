using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAssessment
{
    internal class Menu : Dialog
    {
        public override void Display()
        {
            bool isValid = false;
            while (isValid = false)
            {
                Console.WriteLine(@"+------------------------------+
| Welcome to the Auction House |
+------------------------------+

Main Menu
-------- -
(1) Resgister
(2) Sign In
(3) Exit

Please select an option between 1 and 3");
                string input = Console.ReadLine();
            }

            
        }
    }
}
