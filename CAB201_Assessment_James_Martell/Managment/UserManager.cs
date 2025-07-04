using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    internal class UserManager
    {
        protected List<User> users;
        protected List<SignInUser> signInUser { get; set; } = new List<SignInUser>();

        public UserManager()
        {
            users = new List<User>();
            signInUser = new List<SignInUser>();
        }

        // Declare a list that will be used to store signed in user information
        class ListShare
        {
            public static List<String> DataList { get; set; } = new List<String>();
        }
        
        class List2Share
        {
            public static List<String> Data2List { get; set; } = new List<String>();
        }

        public static class ListUse
        {
            public static void AddData(string username, string email)
            {
                ListShare.DataList.Add(username);
                ListShare.DataList.Add(email);
            }
            public static List<string> GetData()
            {
                List<string> thing = new List<string>();
                thing = ListShare.DataList;
                return thing;
            }
            public static void ClearData()
            {
                ListShare.DataList.Clear();
            }
        }

        public static class List2Use
        {
            public static void AddData(string entry)
            {
                List2Share.Data2List.Add(entry);
            }
            public static List<string> GetData()
            {
                List<string> thing = new List<string>();
                thing = List2Share.Data2List;
                return thing;
            }
            public static void ClearData()
            {
                List2Share.Data2List.Clear();
            }
        }
    }
}
