using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.DAL.Gateway
{
    public class StockInGateway:CommonGateway
    {

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

        public int StockSave(StockIn stockIn)
        {
            string query = "INSERT INTO StockIn (CompanyId, ItemId, AvailableQuantity, StockInQuantity, ItemName)VALUES('" + stockIn.CompanyId + "','" + stockIn.ItemId + "','" + stockIn.StockInQuantity + "','" + stockIn.StockInQuantity + "','" + stockIn.ItemName + "')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

        public int StockUpdate(StockIn model)
        {
            string query = "Update StockIn set AvailableQuantity='" + model.StockInQuantity + "' where ItemId=" + model.ItemId;
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowaffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowaffect;
        }

    }
}