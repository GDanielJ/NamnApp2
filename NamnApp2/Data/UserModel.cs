using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserModel(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
