using Npgsql;
using System;
using System.Configuration;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Junior_Backend_Test
{
    internal class PostgresqlConnection
    {
        private string Connection { get; set; }
        public PostgresqlConnection()
        {
            string path = "../../../appsettings.json";
            string text = File.ReadAllText(path);
            var json = JObject.Parse(text);

            Connection = json["connectionString"].ToString();
        }

        public void ConnectionGetData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection))
            {
                connection.Open();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"Result.xml");
                XmlElement? xRoot = xDoc.DocumentElement;

                XmlElement dbDataElem = xDoc.CreateElement("databasedata");

                XmlText dbConnText = xDoc.CreateTextNode($"Строка подключения: {connection.ConnectionString}");
                XmlText dbStateText = xDoc.CreateTextNode($"Состояние подключения: {connection.State}");
                XmlElement dbConnElem = xDoc.CreateElement("connection");
                XmlElement dbStateElem = xDoc.CreateElement("state");

                dbConnElem.AppendChild(dbConnText);
                dbStateElem.AppendChild(dbStateText);

                dbDataElem.AppendChild(dbConnElem);
                dbDataElem.AppendChild(dbStateElem);

                xRoot?.AppendChild(dbDataElem);
                xDoc.Save(@"Result.xml");

                using (StreamWriter write = File.AppendText("log.txt"))
                {
                    Logging log = new Logging();
                    log.Log($"Строка подключения: {connection.ConnectionString} \n" +
                        $"Состояние подключения: {connection.State}", write);
                    write.Close();
                }

            }
        }

        public void PrintConnectionInfo()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection))
            {
                connection.Open();

                Console.WriteLine($"Строка подключения: {connection.ConnectionString}");
                Console.WriteLine($"Состояние: {connection.State}");
            }
        }
    }
}
