﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Models
{
    public class ItemSearch
    {
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReorderLevel { get; set; }

    }
}