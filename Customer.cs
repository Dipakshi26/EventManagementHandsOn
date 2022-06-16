using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EventManagementHandsOn
{
    internal class Customer
    {
        public static string sqlConnectionStr = @"Data Source=LAPTOP-3AOH9UNJ\SQLEXPRESS;Initial Catalog=EventManagement;Integrated Security=True";
        public DataTable select()
        {
            #region
            SqlConnection sq = new SqlConnection(sqlConnectionStr);
            SqlDataAdapter adp = new SqlDataAdapter("select *from EventTable", sq);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            #endregion
        }

        public void customer(int code)
        {
            #region
            SqlConnection sq = new SqlConnection(sqlConnectionStr);
            SqlDataAdapter adapter = new SqlDataAdapter("insert into CustomerTable (Venue_code,Venue) select Venue_code, Venue from EventTable where Venue_code=" + code, sq);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            #endregion

            #region
            Console.WriteLine("Enter the customer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter customer place");
            string place = Console.ReadLine();
            string approval = "Process in progress";
            Console.WriteLine("Enter the Event Date(YY-MM-DD");
            object date = Console.ReadLine();
            Console.WriteLine("Enter your Mobile Number");
            long num = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter event name");
            string eventName = Console.ReadLine();

            SqlConnection sq2 = new SqlConnection(sqlConnectionStr);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("update CustomerTable set Customer_Name='" + name + "',place='" + place + "',Event_Approval='" + approval +"',Event_Date ='" + date + "'Event_Name='" + eventName + "'Moblie_Number=" + num + "where Venue_code=" + code, sq);
            DataTable d = new DataTable();
            sqlDataAdapter.Fill(d);
            Console.WriteLine("Will apporve soon");
            #endregion
        }
        public DataTable show(long a)
        {
            #region
            SqlConnection sq = new SqlConnection(sqlConnectionStr);
            SqlDataAdapter adp = new SqlDataAdapter("select *from CustomerTable where Moblie_Number=" + a, sq);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            #endregion

        }

        public DataTable ssw()
        {
            #region
            SqlConnection sq = new SqlConnection(sqlConnectionStr);
            SqlDataAdapter adp = new SqlDataAdapter("select *from CustomerTable", sq);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            #endregion
        }

        public string up(long numb)
        {
            Console.WriteLine("Apporved or Not Approved");
            string asd = Console.ReadLine();
            #region
            SqlConnection sqm = new SqlConnection(sqlConnectionStr);
            SqlDataAdapter adps = new SqlDataAdapter("update CustomerTable set Event_Approval='" + asd + "' where Moblie_Number=" + numb, sqm);
            DataTable dta = new DataTable();
            adps.Fill(dta);
            return "Updated";
            #endregion

        }
    }
}

