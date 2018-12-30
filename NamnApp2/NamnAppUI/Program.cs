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
                    case "3":
                        SearchUser();
                        Console.ReadLine();
                        break;
                    case "4":
                        DeleteUser();
                        Console.ReadLine();
                        break;
                    case "5":
                        ChangeUser();
                        Console.ReadLine();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
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
            var first = Console.ReadLine(); // varför "var" här och inte string? Förstår att man kan byta ut de flesta (alla?) datatyper mot var, men varför inte skriva ut explicit?
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
            Action<string, string, string> printTableRow = (a, b, c) => Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|", a, b, c)); // Vad gör "15" i hakparantesen här?

            var users = UserRep.GetAll();

            printTableRow("Id", "Firstname", "Lastname");
            foreach (var user in users)
            {
                printTableRow(user.Id.ToString(), user.FirstName, user.LastName);
            }
        }

        public static void DeleteUser()
        {
            Console.WriteLine("Id of user to be deleted: ");
            string deleteid = Console.ReadLine();
            bool success = Int32.TryParse(deleteid, out int id);

            if (success)
            {
                UserRep.Delete(id);
                Console.WriteLine($"User with id {id} was deleted successfully.");
            }
            else
            {
                Console.WriteLine($"User with id {deleteid} could not be deleted.");
            }
        }

        public static void ChangeUser()
        {
            Console.WriteLine("Id of user to be changed: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("New firstname: ");
            string first = Console.ReadLine();
            Console.WriteLine("New lastname: ");
            string last = Console.ReadLine();

            UserModel user = new UserModel(id, first, last);
            var updatedUser = UserRep.Update(user);

            if (updatedUser != null)
                Console.WriteLine("User was updated.");
            else
                Console.WriteLine("User could not be updated.");
        }

        public static void SearchUser()
        {
            var cUsers = UserRep.GetAll();
            if (cUsers.Count() == 0)
                Console.WriteLine("There are no users yet.");
            else
            {
                Console.WriteLine("Enter \"F\" to search by firstname or \"L\" to search by lastname: ");
                String k = Console.ReadLine().ToUpper();

                var fUsers = new List<UserModel>();
                bool eCom = false;

                if (k == "F") // Det här måste gå att lösa snyggare!
                {
                    Console.WriteLine("Firstname: ");
                    string first = Console.ReadLine();
                    fUsers = UserRep.Search(k, first.ToLower());
                }
                else if (k == "L")
                {
                    Console.WriteLine("Lastname: ");
                    string last = Console.ReadLine();
                    fUsers = UserRep.Search(k, last.ToLower());
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                    eCom = true;
                }
                
                if (eCom == false)
                {
                    Console.WriteLine("Found users: "); // TODO -- Snygga till med samma format som ListUsers
                    foreach (UserModel user in fUsers)
                    {
                        Console.WriteLine($"Id: {user.Id}, Firstname: {user.FirstName}, Lastname: {user.LastName}.");
                    }
                }
            }
        }
    }
}
