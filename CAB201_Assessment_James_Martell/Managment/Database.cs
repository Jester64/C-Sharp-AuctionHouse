using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class Database
    {
        public static string fileName = @"UserStore.txt";
        //public static void Add(List<string> userInformation, string fileName)
        //{ 
        //    if (File.Exists(fileName))
        //    {
        //        using (StreamWriter writer = File.AppendText(fileName)) 
        //        {
        //            writer.WriteLine($"{userInformation[0]},{userInformation[1]},{userInformation[2]},");  Keeping just in case
        //            writer.Flush();
        //            writer.Close();
        //        }
        //    }
        //}
        public static void Add(List<string> userInformation, string fileName)
        {
            if (File.Exists(fileName)) //If the filename can be found, run the below code
            {
                // replace all commas with apostrophes for formatting purposes 
                List<string> formattedInfo = new List<string>();
                foreach (string item in userInformation)
                {
                    formattedInfo.Add(item.Replace(",", "'"));
                }
                //enter information into the database
                using (StreamWriter writer = File.AppendText(fileName)) 
                {
                    foreach (string entry in formattedInfo)
                    {
                        writer.Write($"{entry},");
                    }
                    writer.WriteLine("");
                }
            }
        }
        public static string[] Retrieve(string fileName)
        {
            if (File.Exists(fileName))
            {
                //set up some values
                StreamReader reader = new StreamReader(fileName);
                string lines = "";
                string[] data = { };
                List<string> manage = new List<string>();
                int counter = 0;
                
                // Take all info from the database and put it in a list (seperate each entry on commas)
                while (!reader.EndOfStream)
                {
                    lines = reader.ReadLine();
                    data = lines.Split(',');
                    foreach (string info in data)
                    {
                        manage.Add(info);
                    }
                }

                //Replace apostrophes with commas
                List<string> formattedManage = new List<string>();
                foreach (string item in manage)
                {
                    formattedManage.Add(item.Replace("'", ","));
                }

                data = formattedManage.ToArray(); //put data in an array
                reader.Close();
                reader.Dispose();

                return data;
            }
            else return null;
        }

        public static void Edit(string filename, string[] inputData, int entrylength)
        {
            // replace all commas with apostrophes for formatting purposes 
            //List<string> formattedInfo = new List<string>();
            //foreach (string item in inputData)
            //{
            //    formattedInfo.Add(item.Replace(",", "'"));
            //}

            using StreamWriter w = new StreamWriter(filename);

            int count = 0;
            for (int i = 0; i < inputData.Length; i++)
            {
                w.Write($"{inputData[i]}");
                count++;

                if (count == entrylength) 
                {
                    w.WriteLine("");
                    count = 0;
                }
                else { w.Write(","); }
            }

        }
    }
}
