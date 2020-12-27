using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using classes;
using School_Journal_App_VSProject.classes;

namespace School_Journal_App_VSProject.classes
{
    class SQLController
    {
        public static SQLController controller = new SQLController();
        public static string sql;
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;

        public SQLController()
        {
            con = new SqlConnection();
            cmd = new SqlCommand("", con);
        }

        public void Open() 
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = "Data Source=DESKTOP-5LEEG3R;Initial Catalog=School-Journal-App-DB;Integrated Security=True";
                    con.Open();
                }
            }
            catch
            {
            }
        }

        public void Close()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {
            }
        }

        public SqlDataReader Select(string from, List<string> what = null, Dictionary<string, object> where = null) 
        {
            if (con.State == ConnectionState.Closed) Open();

            string SQLWhat = "*";
            if (what != null && what.Count > 0) 
            {
                SQLWhat = string.Join(", ", what);
            }
            string SQLWhere = "";
            List<string> whereList = new List<string>();
            if (where != null)
            {
                SQLWhere = " WHERE ";
                foreach (var item in where)
                {
                    string value = "";

                    if (item.Value == null) 
                    {
                        value = "NULL";
                    }

                    if (item.Value is int)
                    {
                        value = ""+item.Value;
                    }

                    if (item.Value is string)
                    {
                        value = "'" + item.Value + "'";
                    }

                    whereList.Add(item.Key + " = " + value);
                }
                if (whereList.Count > 0)
                    SQLWhere += string.Join(", ", whereList);
            }

            sql = "SELECT " + SQLWhat + " FROM " + from + " " + SQLWhere;

            cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public User GetUser(string login)
        {
            User user = new User();

            Open();

            SqlDataReader reader = Select(Database.Users.TABLE_NAME, null, new Dictionary<string, object> 
            { 
                [Database.Users.LOGIN] = login
            });

            if (reader.Read())
            {
                string middleName = "";
                int group = 0;

                try
                {
                    middleName = reader.GetString(2);
                }
                catch { }
                try
                {
                    group = reader.GetInt32(4);
                }
                catch { }

                user = new User(
                    reader.GetString(7),
                    reader.GetString(8),
                    new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1), middleName),
                    group,
                    reader.GetString(6),
                    reader.GetInt32(9)
                );
            }

            Close();

            return user;
        }

        public List<Group> getGroups() 
        {
            List<Group> groups = new List<Group>();

            Open();

            SqlDataReader reader = Select(Database.Groups.TABLE_NAME);

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    groups.Add(new Group(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    ));
                }
            }

            Close();

            return groups;
        }

        public List<Subject> getSubjectsForGroups(int groupId)
        {
            List<Subject> groups = new List<Subject>();

            Open();

            SqlDataReader reader = Select(Database.Subjects.TABLE_NAME, null, new Dictionary<string, object> {
                [Database.Subjects.GROUP_ID] = groupId
            });

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    groups.Add(new Subject(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3)
                    ));
                }
            }

            Close();

            return groups;
        }

    }
}
