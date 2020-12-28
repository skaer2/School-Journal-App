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

        public void InsertUser(string firstName, string lastName, string middleName, int groupId, string email, string login, string _password, int role)
        {
            Open();

            sql = "INSERT INTO [dbo].[users] ([first_name] ,[last_name], [middle_name] ,[birthday] ,[group_id] ,[email] ,[login] ,[password] ,[role])" + 
                "VALUES (@firstName, @lastName, @middleName, '10.10.2010', @groupId, @email, @login, @password, @role)"; 
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@middleName", middleName);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", _password);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.ExecuteNonQuery();

            Close();
        }

        internal void InsertSubject(string title, string teacherId, int groupId)
        {
            Open();

            sql = "INSERT INTO [dbo].[subjects] ([title], [teacher_id], [group_id])" +
                "VALUES (@title, @teacherId, @groupId)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@teacherId", teacherId);
            cmd.Parameters.AddWithValue("@groupId", groupId);
            cmd.ExecuteNonQuery();

            Close();
        }

        internal void InsertGroup(string title)
        {
            Open();

            sql = "INSERT INTO [dbo].[groups] ([title])" +
                "VALUES (@title)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.ExecuteNonQuery();

            Close();
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

        public void Insert(string table, List<string> to = null, List<object> value = null) 
        {
            Open();

            string SQLWhat = "";
            string SQLValue = "";
            if (to != null && to.Count > 0)
            {
                SQLWhat = " (";
                SQLWhat += string.Join(", ", to);
                SQLWhat += ")";
            }

            if (value != null && value.Count > 0)
            {
                SQLValue = "(";
                List<string> whereList = new List<string>();

                foreach (var item in value)
                {
                    string str = "";
                    if (item == null)
                    {
                        str = "NULL";
                    }

                    if (item is int)
                    {
                        str = "" + item;
                    }

                    if (item is string)
                    {
                        str = "'" + item + "'";
                    }

                    whereList.Add(str);
                }
                SQLValue += string.Join(", ", whereList);
                SQLValue += ")";
            }

            sql = "INSERT INTO " + table + " " + SQLWhat + "VALUES " + SQLValue;
            Console.WriteLine(sql);
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            Close();
        }

        public void Delete(string table, Dictionary<string, object> where = null)
        {
            Open();

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
                        value = "" + item.Value;
                    }

                    if (item.Value is string)
                    {
                        value = "'" + item.Value + "'";
                    }

                    whereList.Add(item.Key + " = " + value);
                }
                if (whereList.Count > 0)
                    SQLWhere += string.Join(" AND ", whereList);
            }

            sql = "DELETE FROM " + table + SQLWhere;
            Console.WriteLine(sql);
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();

            Close();
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



        public List<User> getUsersForGroup(int groupId) {
            List<User> users = new List<User>();

            Open();

            SqlDataReader reader = Select(Database.Users.TABLE_NAME, null, new Dictionary<string, object> {
                [Database.Users.GROUP_ID]=  groupId
            });

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
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

                    users.Add(new User(
                        reader.GetString(7),
                        reader.GetString(8),
                        new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1), middleName),
                        group,
                        reader.GetString(6),
                        reader.GetInt32(9)
                    ));
                }
            }

            Close();

            return users;
        }

        public List<User> getUsersWithRole(int role)
        {
            List<User> users = new List<User>();

            Open();

            SqlDataReader reader = Select(Database.Users.TABLE_NAME, null, new Dictionary<string, object>
            {
                [Database.Users.ROLE] = role
            });

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
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

                    users.Add(new User(
                        reader.GetString(7),
                        reader.GetString(8),
                        new Tuple<string, string, string>(reader.GetString(0), reader.GetString(1), middleName),
                        group,
                        reader.GetString(6),
                        reader.GetInt32(9)
                    ));
                }
            }

            Close();

            return users;
        }

        public List<Group> getGroups(int id = -1) 
        {
            List<Group> groups = new List<Group>();

            Open();
            SqlDataReader reader;
            if (id == -1)
            {
                reader = Select(Database.Groups.TABLE_NAME);
            }
            else 
            {
                reader = Select(Database.Groups.TABLE_NAME,null, new Dictionary<string, object> {
                    [Database.Groups.ID] = id
                });
            }
            

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
                        reader.GetString(2),
                        reader.GetInt32(3)
                    ));
                }
            }

            Close();

            return groups;
        }
    }
}
