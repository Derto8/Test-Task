using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Junior_Backend_Test
{
    internal static class PostgresqlConnection
    {
        private static string connectionData = ConfigurationManager.ConnectionStrings["ConnectionToDB"].ConnectionString;

        public static async Task Connection()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionData))
            {
                await connection.OpenAsync();
                Console.WriteLine("Подключение открыто!");

                // Вывод информации о подключении
                Console.WriteLine($"Строка подключения: {connection.ConnectionString}");
                Console.WriteLine($"Состояние: {connection.State}");
            }

            Console.WriteLine("Подключение закрыто");
        }
    }
}
