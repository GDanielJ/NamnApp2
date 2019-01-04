using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TextConnector
    {
        // Skapa metod
        // läs data från textfil
        // spara ner data i UserRepository, som sedan ska användas i UserRep i Program när applikationen startas upp

        // metod för att skriva data till textfil

        private const string FilePath = @"C:\Demo\Test.txt";

        public List<string> lines = File.ReadAllLines(FilePath).ToList();

        public UserRepository LoadFile()
        {
            UserRepository loadedUsers = new UserRepository();

            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                UserModel u = new UserModel(int.Parse(entries[0]), entries[1], entries[2]);
                loadedUsers.AddExisting(u);
            }

            return loadedUsers; 
        }

        public int SaveFile(IEnumerable<UserModel> users)
        {
            int usersSaved = 0;
            List<string> output = new List<string>();

            foreach (UserModel user in users)
            {
                output.Add($"{user.Id},{user.FirstName},{user.LastName}");
                usersSaved++;
            }

            File.WriteAllLines(FilePath, output);

            return usersSaved;
        }
    }
}
