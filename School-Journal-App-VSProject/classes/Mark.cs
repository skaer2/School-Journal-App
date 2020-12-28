using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Mark
    {
        private readonly int id;
        public int Id { get { return id; } }
        private readonly string mark;
        public string CurrentMark { get { return mark; } }
        private readonly string userLogin;
        public string UserLogin { get { return userLogin; } }
        private readonly int itemId;
        public int ItemId { get { return itemId; } }

        public Mark() { }
        public Mark(int _id, string _mark, string _userLogin, int _itemId)
        {
            id = _id;
            mark = _mark;
            userLogin = _userLogin;
            itemId = _itemId;
        }
    }
}
