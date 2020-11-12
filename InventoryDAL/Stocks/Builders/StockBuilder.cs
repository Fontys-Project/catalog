﻿using InventoryDAL.Interfaces;
using InventoryLogic.Interfaces;
using InventoryLogic.Products;
using InventoryLogic.Stocks;
using System;
using System.IO;

namespace InventoryDAL.Stocks
{
    public class StockBuilder : IStockBuilder
    {
        private readonly IDomainFactory domainFactory;
        private readonly IRepositoryFactory repositoryFactory;
        private readonly StockEntity stockEntity;

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public StockBuilder(StockEntity stockEntity, IDomainFactory domainFactory, IRepositoryFactory repositoryFactory)
        {
            this.domainFactory = domainFactory;
            this.repositoryFactory = repositoryFactory;
            this.stockEntity = stockEntity;
            
            this.Id = stockEntity.Id;
            this.ProductId = stockEntity.ProductId;
            this.Date = stockEntity.Date;
            this.Amount = stockEntity.Amount;
        }

        public Stock GetResult()
        {
            Stock stock = domainFactory.CreateStock();
            stock.Id = this.Id;
            stock.ProductId = this.ProductId;
            stock.Amount = this.Amount;
            stock.Date = this.Date;
            return stock;
        }
    }
}

