using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.DAL.Gateway
{
    public class StockOutGateway:CommonGateway
    {
      
        public int StockOutSave(StockOut StockOut)
        {
            string query = "INSERT INTO StockOut (ItemId, CompanyId, StockOutQty, ItemName, StockStatus,dtEntry)VALUES('" + StockOut.ItemId + "','" + StockOut.CompanyId + "','" + StockOut.StockOutQuantity + "','" + StockOut.ItemName + "','" + StockOut.Status + "', '" + DateTime.Now.ToString("dd-MMM-yyyy") + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public bool IsItemExists(int ItemId)
        {
            string query = "SELECT * FROM StockIn WHERE ItemId='" + ItemId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool isExists = Reader.HasRows;

            Connection.Close();

            return isExists;
        }
        public int UpdateStockOut(StockOut model)
        {
            string query = "Update StockIn set AvailableQuantity='" + model.StockOutQuantity + "' where ItemId=" + model.ItemId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public Item GetItemInfo(string name)
        {
            Item item = new Item();
            item.ReorderLevel = 0;
            item.AvailableQuantity = 0;

            string query = "SELECT * FROM ItemSetup WHERE ItemName='"+name+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                item.Sl = Convert.ToInt32(Reader["Sl"]);
                item.CompanyName = Reader["CompanyName"].ToString();
            }
            Connection.Close();



            string query3 = "SELECT * FROM StockIn WHERE ItemId=" + item.Sl;
            Command = new SqlCommand(query3, Connection);
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
        public int GetStock(int ItemId)
        {
            int stockQty = 0;
            string query3 = "SELECT * FROM StockIn WHERE AvailableQuantity=" + ItemId;
            Command = new SqlCommand(query3, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                Reader.Read();
                stockQty = Convert.ToInt32(Reader["AvailableQuantity"]);
            }
            return stockQty;
        }
        public int StockUpdate(int Available, int itemId)
        {
            string query = "Update StockIn set AvailableQuantity='" + Available + "' where ItemId=" + itemId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

    }
}