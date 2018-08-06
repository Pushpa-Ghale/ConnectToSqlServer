using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace sqltest2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Would you like to 'insert', 'update' or 'delete' the record?");
            string inputCommand = Console.ReadLine();

            switch (inputCommand)
            {
                case "insert":
                    InsertRecord();
                    break;
                case "update":
                    UpdateRecord();
                    break;
                case "delete":
                    DeleteRecord();
                    break;
                default:
                    Console.WriteLine("Please enter correct command");
                    Main(args);
                    break;
            }





        }

        public static void InsertRecord()
        {

            Console.WriteLine("please insert id");
            string cid = Console.ReadLine();

            Console.WriteLine("please insert first name");
            string firstname = Console.ReadLine();

            Console.WriteLine("please insert last name");
            string lastname = Console.ReadLine();

            Console.WriteLine("please insert address ");
            string address = Console.ReadLine();

            Console.WriteLine("please insert your phone number");
            string phonenumber = Console.ReadLine();


            string cmdStr = $"insert into customer(cust_ID, fname, lname, address, phnum ) values ('{cid}' , '{firstname}', '{lastname}', '{address}', {phonenumber})";
            Console.WriteLine(cmdStr);


            ExecuteSqlCmd(cmdStr);

        }

        public static void UpdateRecord()
        {

            Console.WriteLine("Please enter the valid customer ID to update the record");
            string cid = Console.ReadLine();

            Console.WriteLine("Enter the new record for first name");
            string firstname = Console.ReadLine();

            Console.WriteLine("Enter the new record for last name");
            string lastname = Console.ReadLine();

            Console.WriteLine("Enter the address ");
            string address = Console.ReadLine();

            Console.WriteLine("Please enter the newest phone number");
            string phonenumber = Console.ReadLine();


            string cmdStr = $"update customer SET fname = '{firstname}', lname = '{lastname}', address = '{address}', phnum = {phonenumber} where cust_ID = {cid}";
            Console.WriteLine(cmdStr);


            ExecuteSqlCmd(cmdStr);
        }

        public static void DeleteRecord()
        {
            Console.WriteLine("Please enter the valid customer ID to delete the customer record");
            string cid = Console.ReadLine();

            string cmdStr = $"Delete from customer where cust_ID = {cid}";
            Console.WriteLine(cmdStr);

            ExecuteSqlCmd(cmdStr);
        }

        public static void ExecuteSqlCmd(string cmdStr)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["sqlconnection"]);
            SqlCommand cmd = new SqlCommand();

            con.Open();
            SqlCommand myCommand = new SqlCommand(cmdStr, con);
            myCommand.Connection = con;
            myCommand.ExecuteNonQuery();
        }
    }
}
