using System;
using System.Collections.Generic;
using System.Linq;
using DbConnection;

namespace simple_crud
{
    class Program
    {
        static void Read()
        {
            List<Dictionary<string, object>> list = DbConnector.Query("SELECT * FROM Users;");
            System.Console.WriteLine("Id\tName\t\tFave #");
            foreach(Dictionary < string, object > item in list)
            {
                System.Console.WriteLine("{0}\t{1}\t{2}", item["id"], item["FirstName"] + " " + item["LastName"], item["FavoriteNumber"]);
                // foreach(KeyValuePair<string, object> pair in item)
                // {
                //     System.Console.WriteLine("Key is {0}, Value is {1}", pair.Key, pair.Value);
                // }
            }
        }

        static void Create()
        {
            List < Dictionary < string, object>> list = DbConnector.Query("SELECT max(id) FROM Users;");
            int newId = (int)list[0].First().Value + 1;
            System.Console.WriteLine("Please enter the first name:");
            string fname = Console.ReadLine();
            System.Console.WriteLine("Please enter the last name:");
            string lname = Console.ReadLine();
            System.Console.WriteLine("Please enter the favorite number:");
            string favnumstr = Console.ReadLine();
            int favnum = Convert.ToInt32(favnumstr);
            System.Console.WriteLine("You entered the name {0} {1}, with the number {2}", fname, lname, favnum);
            System.Console.WriteLine("Is this correct? (Y/N):");
            string answer = Console.ReadLine();
            if(answer == "y" || answer == "Y" || answer == "yes" || answer == "Yes" || answer == "YES")
            {
                string insQuery = string.Format("INSERT into users (id, FirstName, LastName, FavoriteNumber) VALUES ({0}, \"{1}\", \"{2}\", {3});", newId, fname, lname, favnum);
                DbConnector.Execute(insQuery);
            }
        }
        static void Main(string[] args)
        {
            Create();
            Read();
        }
    }
}
