﻿using InventoryDAL.ProductTag;
using InventoryDAL.Stocks;
using System.Collections.Generic;

namespace InventoryDAL.Products
{
    public class ProductEntity : IProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public IList<ProductTagEntity> ProductTagEntities { get; set; }
        public IList<StockEntity> StockEntities { get; set; }

        public ProductEntity()
        {
            this.ProductTagEntities = new List<ProductTagEntity>();
            this.StockEntities = new List<StockEntity>();
        }
    }
}
