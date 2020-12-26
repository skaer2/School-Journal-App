using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Journal_App_VSProject.classes
{
    public static class Database
    {
        public static class Users {
            public const string TABLE_NAME = "users";
            public const string FIRST_NAME = "first_name";
            public const string LAST_NAME = "last_name";
            public const string MIDDLE_NAME = "middle_name";
            public const string BIRTHDAY = "birthday";
            public const string GROUP_ID = "group_id";
            public const string USER_PHOTO = "user_photo";
            public const string EMAIL = "email";
            public const string LOGIN = "login";
            public const string PASSWORD = "password";
            public const string ROLE = "role";
        }

        public static class Groups
        {
            public const string TABLE_NAME = "groups";
            public const string ID = "group_id";
            public const string TITLE = "title";

        }

        public static class Subjects
        {
            public const string TABLE_NAME = "subjects";
            public const string ID = "subject_id";
            public const string TITLE = "title";
            public const string TEACHER_ID = "teacher_id";
            public const string GROUP_ID = "group_id";

        }

        public static class SubjectItem
        {
            public const string TABLE_NAME = "subject_item";
            public const string ID = "item_id";
            public const string TITLE = "title";
            public const string DATE = "date";
            public const string COMMENT = "comment";
            public const string MAX_MARK = "max_mark";
            public const string FILES = "files";
            public const string SUBJECT_ID = "subject_id";

        }

        public static class Marks
        {
            public const string TABLE_NAME = "marks";
            public const string ID = "mark_id";
            public const string MARK = "mark";
            public const string STUDENT = "student_login";
            public const string ITEM = "item_id";

        }
    }
}
