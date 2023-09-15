using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class DAL
    {
        public const string Connection_String =
            "Source=HP-PAVILION-550;Initial Catalog=Monitoring;Integrated Security=True";

        public static async Task ExecuteNonQueryAsync(string query)
        {
            ThrowIfNullOrEmpty(query);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int affectedrows = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" Database error... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Something went wrong... {ex.Message}");
            }
        }

        public static async Task<T> ExecuteQueryAsync<T>(string query, Func<SqlDataReader, T> converter)
        {
            ThrowIfNullOrEmpty(query);

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection_String))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        return converter(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($" Database error... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong {ex.Message}");
            }

            return default(T);
        }

        private static void ThrowIfNullOrEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }
        }
    }
}
