﻿using InventoryDAL.Database;
using InventoryDAL.Products;
using InventoryLogic.Facade;
using InventoryLogic.Stocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryDAL.Stocks
{
    public class StockEntity : IStockEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        // Constructor used by .net API framwork
        public StockEntity()
        {

        }
    }
}
