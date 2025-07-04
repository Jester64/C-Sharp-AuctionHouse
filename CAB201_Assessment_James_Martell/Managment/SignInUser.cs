using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class SignInUser
    {
        public string SignName { get; }
        public string SignEmail { get; }

        // A global list ment to contain the signed in user's info untill they sign out
        public SignInUser(string name, string email)
        {
            SignName = name;
            SignEmail = email;
        }
    }
}
