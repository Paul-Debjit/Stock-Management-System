using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.DAL.Gateway
{
    public class SellGateway:CommonGateway
    {
        public List<Sell> GetSellItemsBySearch(string dtFrom, string dtTo)
        {
            string query = "SELECT * FROM StockOut where dtEntry between '" + dtFrom + "' and '" + dtTo + "' and StockStatus='Sell'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Sell> Itemlist = new List<Sell>();
            while (Reader.Read())
            {
                Sell item = new Sell();
                item.ItemName = Reader["ItemName"].ToString();
                item.SaleQty = Reader["StockOutQty"].ToString();

                Itemlist.Add(item);

            }

            Connection.Close();
            return Itemlist;
        }
    }
}