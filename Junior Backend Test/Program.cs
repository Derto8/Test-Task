using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using Junior_Backend_Test;
using Npgsql;
using System.Threading.Tasks;

namespace Junior_Backend_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string sAttr = ConfigurationManager.AppSettings.Get("Key0"); //получение одного ключа

            NameValueCollection sAll = ConfigurationManager.AppSettings;

            CheckSite check = new CheckSite();
            foreach (string s in sAll.AllKeys)
            {
                Console.WriteLine($"Сайт: {s} - {sAll.Get(s)} - {check.CheckSite1(sAll.Get(s))}");

            }
            Console.WriteLine();

            var stateBD = PostgresqlConnection.Connection().GetAwaiter();


            Console.ReadLine();
        }
    }
}
