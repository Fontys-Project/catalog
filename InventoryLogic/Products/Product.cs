﻿using InventoryLogic.Tags;
using System.Collections.Generic;
using InventoryLogic.Stocks;

namespace InventoryLogic.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public int? TagId { get; set; }
        public Tag Tag { get; set; }
        public List<Stock> Stocks { get; set; }

        // Constructor used by .net API framwork
        public Product()
        {

        }

        public Product(int id, string name, decimal price, string sku)
        {
            Id = id;
            Name = name;
            Price = price;
            Sku = sku;
        }
    }
}