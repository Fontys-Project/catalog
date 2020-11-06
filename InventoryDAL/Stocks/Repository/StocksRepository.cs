﻿using InventoryLogic.Interfaces;
using InventoryLogic.Stocks;
using System.Collections.Generic;
using System.Linq;

namespace InventoryDAL.Stocks
{
    public class StocksRepository : IStocksRepository
    {
        private readonly IStockEntityDAO stockEntityDAO;
        private readonly IStockConverter stockConverter;

        public StocksRepository(IStockEntityDAO stockEntityDAO, IStockConverter stockConverter)
        {
            this.stockEntityDAO = stockEntityDAO;
            this.stockConverter = stockConverter;
        }

        public void Add(Stock stock)
        {
            stockEntityDAO.Add(stockConverter.ConvertToStockEntity(stock));
        }

        public List<Stock> GetAll()
        {
            return stockEntityDAO.GetAll()
                .Select(entity => stockConverter.ConvertToStock(entity)).ToList();
        }

        public Stock Get(int id)
        {
            StockEntity entity = stockEntityDAO.Get(id);
            return stockConverter.ConvertToStock(entity);
        }

        public void Modify(Stock stock)
        {
            StockEntity entity = stockConverter.ConvertToStockEntity(stock);
            stockEntityDAO.Modify(entity);
        }

        public void Remove(int id)
        {
            stockEntityDAO.Remove(id);
        }
    }
}