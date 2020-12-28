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
        private readonly string teacherLogin;
        public string TeacherLogin { get { return teacherLogin; } }
        private readonly int groupId;
        public int GroupId { get { return groupId; } }

        public Subject(int _id, string _title, string _teacherLogin, int _groupId)
        {
            id = _id;
            title = _title;
            teacherLogin = _teacherLogin;
            groupId = _groupId;
        }
    }
}
