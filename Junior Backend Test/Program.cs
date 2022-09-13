using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
using System.IO;

namespace Junior_Backend_Test
{
    internal class Program
    {
        // пример параметров для командной строки: arg1 arg2 "long argument" 123456
        static void Main(string[] args)
        {
            XMLFile file = new XMLFile();
            PostgresqlConnection conn = new PostgresqlConnection();
            SendFile send = new SendFile();

            if (args.Length == 0)
            {
                Console.WriteLine("В командной строке не заданы параметры");
                Console.WriteLine();
                Console.WriteLine("Идет генерация файла...");
                Console.WriteLine();

                file.GenerateXMLFile();
                conn.ConnectionGetData();
                send.SendToMail();
            }
            else
            {
                Console.WriteLine($"В командной строке задано {args.Length} параметра/ов");
                Console.WriteLine();

                file.PrintInformation();
                Console.WriteLine();
                conn.PrintConnectionInfo();
            }

            Console.ReadLine();
        }
    }
}
