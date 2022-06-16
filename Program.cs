using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----WELCOME TO EVENT MANAGEMENT SYSTEM----");
            Console.WriteLine("Please login to any of the following:");
            Console.WriteLine("1. Super Admin");
            Console.WriteLine("2. Event");
            Console.WriteLine("3. Customer");
            Console.WriteLine("");
  
            SuperAdmin superadmin = new SuperAdmin();
            Event events = new Event();
            Customer customer = new Customer();
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            
            {
                case 1:

                    Console.WriteLine("press 1 to Insert Admin");
                    Console.WriteLine("press 2 to Update Admin");
                    Console.WriteLine("press 3 to delete Admin");
                    int gii = Convert.ToInt32(Console.ReadLine());
                    switch (gii)
                    {
                        case 1:
                            string insert = superadmin.Insert();
                            Console.WriteLine(insert);
                            break;
                        case 2:
                            string update = superadmin.Update();
                            Console.WriteLine(update);
                            break;
                        case 3:
                            Console.WriteLine("Enter the Admin id to delete:");
                            int b = Convert.ToInt32(Console.ReadLine());
                            string delete = superadmin.Delete(b);
                            Console.WriteLine(delete);
                            break;
                    }
                    break;
                case 2:

                    Console.WriteLine("press 1 to Insert New Venue Details");
                    Console.WriteLine("press 2 to Updated Venue Details");
                    Console.WriteLine("press 3 to Delete Venue Details");
                    Console.WriteLine("Press 4 to Update the customer approval");
                    int aa = Convert.ToInt32(Console.ReadLine());
                    switch (aa)
                    {
                        case 1:
                           string n = events.insert();
                            Console.WriteLine(n);
                            break;
                        case 2:
                            string m = events.update();
                            Console.WriteLine(m);
                            break;
                        case 3:
                            Console.WriteLine("Enter the Venue code to Delete:");
                            int s = Convert.ToInt32(Console.ReadLine());
                            string k = events.delete(s);
                            Console.WriteLine(k);
                            break;

                        case 4:
                            DataTable dr = customer.ssw();
                            for (int i = 0; i < dr.Rows.Count; i++)
                            {
                                for (int j = 0; j < dr.Columns.Count; j++)
                                {
                                    Console.WriteLine(dr.Rows[i][j] + "\t");
                                }

                            }
                            Console.WriteLine("To update?Yes or No");
                            string update = Console.ReadLine();
                            if (update == "Yes")
                            {
                                Console.WriteLine("Enter the mobile number which u want update");
                                long mobNo = Convert.ToInt64(Console.ReadLine());
                                customer.up(mobNo);
                            }
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Press 1 book venue");
                    Console.WriteLine("Prees 2  To View the approval details");
                    int select = Convert.ToInt32(Console.ReadLine());
                    switch (select)
                    {
                        case 1:
                            DataTable d = customer.select();
                            for (int i = 0; i < d.Rows.Count; i++)
                            {
                                Console.WriteLine("Avalaible Function Hall Details:");
                                for (int j = 0; j < d.Columns.Count; j++)
                                {
                                    switch (j)
                                    {
                                        case 0:
                                            Console.WriteLine("Venue Code: " + d.Rows[i][j]);
                                            break;
                                        case 1:
                                            Console.WriteLine("Venue: " + d.Rows[i][j]);
                                            break;
                                        case 2:
                                            Console.WriteLine("Capacity of Hall: " + d.Rows[i][j]);
                                            break;
                                        case 4:
                                            Console.WriteLine("Food Items Provides: " + d.Rows[i][j]);
                                            break;
                                        case 5:
                                            Console.WriteLine(" Cost: " + d.Rows[i][j]);
                                            break;

                                    }
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("Do You Want To Book? Yes or No ");
                            string confirm = Console.ReadLine();
                            if (confirm == "Yes")
                            {
                                Console.WriteLine("Enter the Venue code to book:");
                                int h = Convert.ToInt32(Console.ReadLine());
                                customer.customer(h);
                            }
                            else
                            {
                                Console.WriteLine("Have a Nice day");
                            }

                            break;
                        case 2:
                            Console.WriteLine("Enter the Registered Mobile Number");
                            long mobNo = Convert.ToInt64(Console.ReadLine());
                            DataTable dt = customer.show(mobNo);
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    Console.WriteLine(dt.Rows[i][j] + "\t");
                                }
                            }
                            break;
                    }
                    break;
            }
         }
    }
}
