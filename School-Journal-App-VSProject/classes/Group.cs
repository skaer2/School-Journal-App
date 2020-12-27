using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Group
    {
        private readonly int id;
        public int Id { get { return id; } }
        private readonly string title;
        public string Title { get { return title; } }

        public Group(int _id, string _title) {
            id = _id;
            title = _title;
        }
    }
}
