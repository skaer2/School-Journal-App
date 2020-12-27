using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class User
    {
        public User() { }
        public User(string _login, string _password, Tuple<string, string, string> _name, int _groupId, string _email, int _role){
            login = _login;
            name = _name;
            groupId = _groupId;
            email = _email;
            role = _role;
            Password = _password;
        }

        public readonly int role;

        public readonly string login;

        public readonly string email;

        public readonly string photo;

        public readonly int groupId;

        public readonly DateTime birthday;

        public readonly Tuple<string, string, string> name;

        private string password;
        public string Password 
        {
            set 
            {
                if (password == null)
                {
                    password = value;
                }
                else 
                {
                    password = value;
                    // add BD change
                }
            }
        }

        public bool CheckPassword(string chechPassword) 
        {
            if (chechPassword == password)
            {
                return true;
            }
            return false;
        }
    }
}
