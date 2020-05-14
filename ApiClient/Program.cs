using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.Threading;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // string cs = @"server=localhost;userid=dbuser;password=s$cret;database=testdb";
            string cs = @"server=db;userid=root;password=root;database=new_base";

            using var con = new MySqlConnection(cs);
            con.Open();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "DROP TABLE IF EXISTS weather";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE weather(id INTEGER PRIMARY KEY AUTO_INCREMENT,
                    weatherdesc TEXT)";
            cmd.ExecuteNonQuery();

            while (true)
            {
                Thread.Sleep(1000);
                String weatherDesc = new WebClient().DownloadString("http://weather/weatherforecast");
                //
               //  cmd.CommandText = $"INSERT INTO weather(weatherdesc) VALUES({weatherDesc})";
                cmd.CommandText = $"INSERT INTO weather(weatherdesc) VALUES('"+ weatherDesc + "')";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
