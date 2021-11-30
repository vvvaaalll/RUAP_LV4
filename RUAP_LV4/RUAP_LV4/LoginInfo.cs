using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUAP_LV4
{
    class LoginInfo
    {
        private String email;
        private String password;

        public LoginInfo(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public String getEmail() {
            return email;
        }

        public String getPassword()
        {
            return password;
        }
        public void setEmail(String email) {
            this.email = email;
        }
    }
}
