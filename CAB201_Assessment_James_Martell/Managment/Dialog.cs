using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal abstract class Dialog
    {
        public abstract string Title { get; }
        
        public abstract void Display();

        public static void ShowTitle(string title)  // a repeticive function in all display calls made to a single action
        {
            Console.WriteLine("");
            Console.WriteLine(title);
            foreach (char thing in title) { Console.Write("-"); }
            Console.WriteLine("");

        }
    }
}
