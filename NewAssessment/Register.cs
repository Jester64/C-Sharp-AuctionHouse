using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAssessment
{
    internal class Register : Dialog
    {
        public override void Display()
        {
            Console.WriteLine("Please enter your name");
            string input = Console.ReadLine();
        }
    }
}
