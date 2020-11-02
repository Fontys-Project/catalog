﻿using InventoryLogic.Facade;
using InventoryLogic.Stocks;
using InventoryLogic.Tags;
using InventoryLogic.Products;
using System;
using System.Collections.Generic;

namespace InventoryLogic.Stocks
{
    public class StockDTO : IHasUniqueObjectId
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}