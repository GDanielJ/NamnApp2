using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserModel
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserModel(int id, string firstname, string lastname)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
