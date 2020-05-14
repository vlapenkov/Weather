using MySql.Data.MySqlClient;
using System;
using System.Threading;

namespace DBReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //  string cs = @"server=localhost;userid=dbuser;password=s$cret;database=mydb";
                string cs = @"server=db;userid=root;password=root;database=new_base";

                using var con = new MySqlConnection(cs);
                con.Open();

                MySqlCommand command = con.CreateCommand();
               
                command.CommandText = "SELECT COUNT(*) FROM weather";
               
               
                while (true)
                {
                    Thread.Sleep(1000);
                 
                    var weather = command.ExecuteScalar().ToString();
                    Console.WriteLine($"The weather is: {weather}");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
