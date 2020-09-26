using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.DAL.Gateway
{
    public class ItemGateway : CommonGateway
    {
        public int ItemSave(Item item)
        {
            string query = "INSERT INTO ItemSetup VALUES('" + item.CategoryName + "','" + item.CompanyName + "','" +
                           item.ItemName + "','" + item.ReorderLevel + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public bool IsItemExists(string item)
        {
            string query = "SELECT * FROM ItemSetup WHERE ItemName='" + item + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }

        public List<Item> GetAllItems()
        {
            string query = "SELECT * FROM ItemSetup";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Item> Itemlist = new List<Item>();
            while (Reader.Read())
            {
                Item item = new Item();
                item.Sl = Convert.ToInt32(Reader["Sl"]);
                item.CategoryName = Reader["CategoryName"].ToString();
                item.CompanyName = Reader["CompanyName"].ToString();
                item.ItemName = Reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                Itemlist.Add(item);

            }

            Connection.Close();
            return Itemlist;
        }
        public Item GetItemById(int Id)
        {
            string query = "SELECT * FROM ItemSetup WHERE Sl=" + Id;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Item item = new Item();
            item.Sl = Convert.ToInt32(Reader["Sl"]);
            item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
          
            Connection.Close();
            return item;
        }


        public Item GetReorderLabel(int ItemId)
        {
            Item item = new Item();
            item.ReorderLevel = 0;
            item.AvailableQuantity = 0;
            string query = "SELECT * FROM ItemSetup WHERE sl=" + ItemId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                item.Sl = Convert.ToInt32(Reader["Sl"]);
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
            }
            Connection.Close();
            string query2 = "SELECT * FROM StockIn WHERE ItemId=" + ItemId;
            Command = new SqlCommand(query2, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
            }

            Connection.Close();
            return item;
        }

        public List<ItemSearch> GetItemsSearch(string companyId, string categoryId)
        {
            string aQuery = "SELECT I.ItemName,C.Name as CompanyName, S.AvailableQuantity,S.AvailableQuantity as Qty,I.ReorderLevel FROM ItemSetup I left outer join StockIn S on S.itemId = I.Sl left outer join Company C on C.Sl = I.CompanyName left outer join CategorySetup CA on CA.Sl = I.CategoryName WHERE C.Sl = '" + companyId + "'  or CA.Sl = '" + categoryId + "' ";
            Command = new SqlCommand(aQuery, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemSearch> Itemlist = new List<ItemSearch>();
            while (Reader.Read())
            {
                ItemSearch item = new ItemSearch();
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                item.CompanyName = Reader["CompanyName"].ToString();
                item.ItemName = Reader["ItemName"].ToString();
                item.Quantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                Itemlist.Add(item);

            }

            Connection.Close();
            return Itemlist;
        }
    }
}