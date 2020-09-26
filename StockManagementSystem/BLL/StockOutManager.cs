using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Models;

namespace StockManagementSystem.BLL
{
    public class StockOutManager
    {
        StockOutGateway stockIOutGateway = new StockOutGateway();
        StockInGateway stockInGateway = new StockInGateway();



        public string StockOutUpdate(StockOut stock)
        {
            Item model = new Item();
            model = stockIOutGateway.GetItemInfo(stock.ItemName);
            stock.ItemId = model.Sl;
            stock.CompanyId = model.CompanyName;

                int available = model.AvailableQuantity;
                available = available-stock.StockOutQuantity;
                 model.AvailableQuantity = available;
                int rowAffect = stockIOutGateway.StockOutSave(stock);
             
                 stockIOutGateway.StockUpdate(available,model.Sl); 

            if (rowAffect > 0)
                {
                    return "Stock Update";
                }
                else
                {
                    return "! Faild";
                }

            }
    }
}