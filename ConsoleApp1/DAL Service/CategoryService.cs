using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL_Service
{
    internal class CategoryService
    {
        private const string TABLE_NAME = "dbo.Category";

        public static async Task<List<Category>> GetAlLCategoriesAsync()
        {
            string query = $"SELECT * FROM {TABLE_NAME};";

            return await DAL.ExecuteQueryAsync(query, ReaderToCategoryList);
        }

        public static async Task<Category> GetCategoryById(int id)
        {
            string query = $"SELECT *" +
                $"FROM {TABLE_NAME}" +
                $" WHERE Id = {id}";

            return await DAL.ExecuteQueryAsync(query, ReadToCategory);
        }

        public static async Task CreateCategory(Category newCategory)
        {
            ThrowIfNull(newCategory);

            string command = $"INSERT INTO {TABLE_NAME} (Name) VALUES ('{newCategory.Name}')";

            await DAL.ExecuteNonQueryAsync(command);
        }

        public static async Task UpdateCategory(Category categoryToUpdate)
        {
            ThrowIfNull(categoryToUpdate);

            string command = $"UPDATE {TABLE_NAME} SET Name = '{categoryToUpdate.Name}'" +
                $"WHERE Id = {categoryToUpdate.Id}";

            await DAL.ExecuteNonQueryAsync(command);
        }

        public static async Task DeleteCategory(int id)
        {
            string command = $"DELETE {TABLE_NAME} WHERE Id = {id}";

            await DAL.ExecuteNonQueryAsync(command);
        }

        private static Category ReadToCategory(SqlDataReader reader)
        {
            ThrowIfNull(reader);

            if (reader.HasRows)
            {
                Category category = null;
                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };
                }

                return category;
            }

            return null;
        }

        private static List<Category> ReaderToCategoryList(SqlDataReader reader)
        {
            ThrowIfNull(reader);

            List<Category> result = new List<Category>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Category category = new Category
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    };

                    result.Add(category);
                }
            }

            return result;
        }

        private static void ThrowIfNull<T>(T value) where T : class
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }
}
