using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.DAL.Gateway
{
    public class CategoryGateway : CommonGateway
    {
        public int CategorySave(Category category)
        {
            string query = "INSERT INTO CategorySetup VALUES('" + category.Name + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categorielist = new List<Category>();
            try {
                string query = "SELECT * FROM CategorySetup";
                Command = new SqlCommand(query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
               
                while (Reader.Read())
                {
                    Category category = new Category();
                    category.Sl = Convert.ToInt32(Reader["Sl"]);
                    category.Name = Reader["Name"].ToString();

                    categorielist.Add(category);

                }

                Connection.Close();
                return categorielist;
            }
            catch (Exception ex)
            {

            }
            return categorielist;
        }

        public bool IsCategoryExists(string category)
        {
            string query = "SELECT * FROM CategorySetup WHERE Name='" + category + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }

        public int Update(Category category)
        {
            string query = "UPDATE CategorySetup SET Name='" + category.Name + "' WHERE Sl=" + category.Sl;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowafect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowafect;
        }

        public Category GetCategoryById(int Id)
        {
            string query = "SELECT * FROM CategorySetup WHERE Sl=" + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Category category = new Category();
            category.Sl = Convert.ToInt32(Reader["Sl"]);
            category.Name = Reader["Name"].ToString();
      
            Connection.Close();
            return category;
        }
    }
}