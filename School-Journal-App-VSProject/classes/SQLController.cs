using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows;
using System.Data.SqlClient;

namespace Demo.classes
{
    class SQLController
    {
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

        public static void open() 
        {

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = "";
                    con.Open();
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message.ToString(), "WPF C# SQL Test", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static void close()
        {

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "WPF C# SQL Test", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static string getName(string login)
        {
            try
            {
                cmd.CommandText = "SELECT first_name, last_name FROM users WHERE login = @login";
                cmd.Parameters.AddWithValue("@login", login);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine(reader["first_name"] + " " + reader["last_name"] + "\n");
                    }
                }

                return "";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString(), "WPF C# SQL Test", MessageBoxButton.OK, MessageBoxImage.Error);
                return "error";
            }


        }

    }
}
