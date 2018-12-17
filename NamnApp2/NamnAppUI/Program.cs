using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace NamnAppUI
{
    class Program
    {
        public static UserRepository UserRep = new UserRepository();

        public static void Main(string[] args)
        {
            string key;
            do
            {
                Console.Clear();
                DisplayMenu();
                key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        AddUser();
                        Console.ReadLine(); // Varför denna raden här?
                        break;
                    case "2":
                        ListUser();
                        Console.ReadLine();
                        break;
                    default:
                        // TODO - Implementera resterande metoder
                        Console.WriteLine("Not yet implemented.");
                        Console.ReadLine();
                        break;
                }

            } while (key != "6");

        }

        public static void DisplayMenu()
        {
            Console.WriteLine("User Manager");
            Console.WriteLine();
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. List user");
            Console.WriteLine("3. Search for user");
            Console.WriteLine("4. Delete user");
            Console.WriteLine("5. Change user");
            Console.WriteLine("5. Exit");
        }

        public static void AddUser()
        {
            // TODO - Implement method
        }

        public static void ListUser()
        {
            // TODO - Implement method
        }
    }
}
