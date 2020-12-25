using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class User
    {
        public User(string login){
            this.login = login;
            this.Photo = System.AppDomain.CurrentDomain.BaseDirectory + "icons\\defaultProfile.jpg";
            //get all the info from the DB
        }

        public int Role { get; set; }

        private string login;

        public string GetLogin()
        {
            return login;
        }

        public string Email { get; set; }
        public string Photo { get; set; }
        public int GroupId { get; set; }
        public DateTime Birthday { get; set; }
        public Tuple<string, string, string> Name { get; set; }
        public string Password { get; set; }
    }
}
