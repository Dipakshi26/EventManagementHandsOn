using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagementHandsOn
{
    internal class SuperAdmin
    {
        public static string str = @"Data Source=LAPTOP-3AOH9UNJ\SQLEXPRESS;Initial Catalog=EventManagement;Integrated Security=True";
        public string Insert()
        {

            Console.WriteLine("---------------WELCOME TO ADMIN MUDULE---------------");
            Console.WriteLine("Admin is allowed to Manage All Events.");

            Console.WriteLine("Enter the new Admin Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new Admin Name:");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the new Admin Role:");
            string eventRole = Console.ReadLine();
            SqlConnection sqlConnection = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("insert into AdminTable values(" + id + ",'" + Name + "','" + eventRole + "')", sqlConnection);
            sqlConnection.Open();
            int a = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (a == 0)
            {
                return "Not Inserted";
            }
            return "Inserted";
        }
        public string Update()
        {
            Console.WriteLine("Enter the Admin Id to be upadated:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new Admin Name to be upadated :");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter the new Admin Role to be upadated:");
            string eventRole = Console.ReadLine();
            SqlConnection sqlConnection = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update AdminTable set admin_Name='" + Name + "', admin_Role='" + eventRole + "'where admin_Id=" + id + "", sqlConnection);
            sqlConnection.Open();
            int a = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (a == 0)
            {
                return "Not Updated";
            }
            return "Updated";

        }
        public string Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("delete from AdminTable where admin_Id=" + id, sqlConnection);
            sqlConnection.Open();
            int a = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (a == 0)
            {
                return "Not Deleted";
            }
            return "Deleted";

        }

    }
}
