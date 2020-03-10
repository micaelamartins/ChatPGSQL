using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
   public partial class Users
    {
        public String Username;
        public String Password;

        public Users()
        {

        }
        public Users (String username, String password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
