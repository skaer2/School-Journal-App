using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class Subject
    {
        private readonly int id;
        public int Id { get { return id; } }
        private readonly string title;
        public string Title { get { return title; } }
        private readonly int teacherId;
        public int TeacherId { get { return teacherId; } }
        private readonly int groupId;
        public int GroupId { get { return groupId; } }

        public Subject() { }
        public Subject(int _id, string _title, int _teacherId, int _groupId)
        {
            id = _id;
            title = _title;
            teacherId = _teacherId;
            groupId = _groupId;
        }
    }
}
