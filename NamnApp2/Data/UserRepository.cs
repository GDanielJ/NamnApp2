using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository
    {
        public List<UserModel> _users;

        public UserRepository()
        {
            _users = new List<UserModel>();
        }

        // Inte helt med på denna men tror jag förstår. IEnumerable gör att man kan iterera över elementen (om det är rätt ord)
        // i _users och GetAll() returnerar innehållet i _users. I GetAll() är IEnumerable<UserModel> "returtypen". Men är
        // IEnumberable också en datatyp, då det ser ut så, på samma sätt som int är returtyp i följande metod:
        // public int MyFunction();
        // Eller hur funkar det här?
        public IEnumerable<UserModel> GetAll() => _users; 

        public UserModel Create(string firstname, string lastname)
        {
            var user = new UserModel(firstname, lastname);
            _users.Add(user);
            return user;
        }

    }
}
