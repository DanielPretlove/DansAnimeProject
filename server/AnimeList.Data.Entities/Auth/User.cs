using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Data.Entities.Auth
{
    public class User : DataEntitiy
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailCount { get; set; }
    }
}
