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


    }
}
