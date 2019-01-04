using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository
    {
        public List<UserModel> _users; // Varför prefix "_" här i variabelnamenet? För att indikera att det är en lista?

        public UserRepository()
        {
            _users = new List<UserModel>();
        }

        // Inte helt med på denna men tror jag förstår. IEnumerable gör att man kan iterera över elementen (om det är rätt ord)
        // i _users och GetAll() returnerar innehållet i _users. I GetAll() är IEnumerable<UserModel> "returtypen". Men
        // är inte IEnumerable ett interface?
        // Här verkar det som att IEnumberable också är en datatyp, då det ser ut så, på samma sätt som int är returtyp i 
        // följande metod:
        // public int MyFunction();
        // Eller hur funkar det här?
        public IEnumerable<UserModel> GetAll() => _users; 

        public UserModel Create(string firstname, string lastname)
        {
            var user = new UserModel((_users.Count + 1), firstname, lastname); 
            _users.Add(user);
            return user;
        }

        public void AddExisting(UserModel existingUser)
        {
            _users.Add(existingUser);
        }

        public void Delete(int id) => _users.RemoveAll(u => u.Id == id);

        public UserModel Update(UserModel user)
        {
            if (!_users.Any(u => u.Id == user.Id))
                throw new Exception($"User with Id {user.Id} could not be found.");

            var currentUser = _users.First(u => u.Id == user.Id);
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            return currentUser;
        }

        public List<UserModel> Search(string choice, string name)
        {

            var foundUsers = new List<UserModel>();

            int lengthName = name.Length;

            if (choice == "F") // det här måste gå att lösa snyggare...
            {
                foreach (UserModel user in _users)
                {
                    string uFirstname = user.FirstName.ToLower();
                    if (uFirstname.Substring(0, lengthName) == name)
                    {
                        foundUsers.Add(user);
                    }
                }
            }
            if (choice == "L")
            {
                foreach (UserModel user in _users)
                {
                    string uLastname = user.LastName.ToLower();
                    if (uLastname.Substring(0, lengthName) == name)
                    {
                        foundUsers.Add(user);
                    }
                }
            }
            return foundUsers;
        }
    }
}
