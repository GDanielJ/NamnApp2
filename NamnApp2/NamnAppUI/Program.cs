using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace NamnAppUI
{
    public class Program
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
            Console.WriteLine("6. Exit");
        }

        public static void AddUser()
        {
            Console.WriteLine("Firstname: ");
            var first = Console.ReadLine(); // varför "var" här och inte string?
            Console.WriteLine("Lastname: ");
            var last = Console.ReadLine();

            var user = UserRep.Create(first, last);

            if (user != null)
                Console.WriteLine("User was created.");
            else
                Console.WriteLine("User could not be created.");
        }

        public static void ListUser()
        {
            // TODO - Implement method
            Action<string, string> printTableRow = (a, b) => Console.WriteLine(String.Format("")); // Ej klar
        }
    }
}
