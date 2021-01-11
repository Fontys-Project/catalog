﻿using InventoryDAL.Interfaces;
using InventoryLogic.Products;
using InventoryLogic.Stocks;
using InventoryLogic.Tags;
using System;
using System.Collections.Generic;

namespace InventoryDAL.Factories
{
    public class DomainFactory : IDomainFactory
    {
        public Product CreateProduct(int id, string name, decimal price, string sku, List<Tag> tags, List<Stock> stocks)
        {
            return new Product(id, name, price, sku, tags, stocks);
        }

        public Stock CreateStock(int id, int productId, int amount, DateTime date, Product product = null)
        {
            return new Stock(id, productId, amount, date, product);
        }

        public Tag CreateTag(int id, string name, List<Product> products)
        {
            return new Tag(id, name, products);
        }
    }
}
