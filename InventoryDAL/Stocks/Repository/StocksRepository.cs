﻿using InventoryDAL.Interfaces;
using InventoryLogic.Interfaces;
using InventoryLogic.Stocks;
using System.Collections.Generic;
using System.Linq;

namespace InventoryDAL.Stocks
{
    public class StocksRepository : IStocksRepository
    {
        private readonly IConverterFactory converterFactory; 
        private readonly IStockEntityDAO stockEntityDAO;
        private readonly Dictionary<Stock, IStockEntity> stockCache;


        public StocksRepository(IStockEntityDAO stockEntityDAO, IConverterFactory converterFactory)
        {
            this.converterFactory = converterFactory; 
            this.stockEntityDAO = stockEntityDAO;
            stockCache = new Dictionary<Stock, IStockEntity>();
        }


        // Handle cacheing of object on instantiation
        private void OnObjectCreation(Stock stock, IStockEntity stockEntity)
        {
            if(!stockCache.ContainsValue(stockEntity))
                stockCache.Add(stock, stockEntity);
        }

        public List<Stock> GetAll()
        {
            List<StockEntity> stockEntities = stockEntityDAO.GetAll();
           
            // Trigger with where, only stocks not cached, and then select all uncached stock entities to convert Stocks that will be added
            // to the cache with the OnObjectCreation delegate.
            stockEntities.Where(stockEntity => stockCache.Values.Any(cacheEntity => stockEntity.Id == cacheEntity.Id) == false)
            .ToList().ForEach(stockEntity => converterFactory.stockConverter.Convert(stockEntity,OnObjectCreation));
          
            return stockCache.Keys.ToList<Stock>();
        }


        public Stock Get(int id)
        {
            Stock stock = stockCache.Keys.Where(s => s.Id == id).FirstOrDefault();
            if (stock == null)
            {
                StockEntity stockEntity = stockEntityDAO.Get(id);
                return converterFactory.stockConverter.Convert(stockEntity, OnObjectCreation);
            }
            else
            {
                return stock;
            }
        }

        public Stock Add(Stock stock)
        {
            StockEntity stockEntity = converterFactory.stockEntityConverter.Convert(stock);
            stockEntity = stockEntityDAO.Add(stockEntity);
            return converterFactory.stockConverter.Convert(stockEntity, OnObjectCreation);
        }

        public void Modify(Stock stock)
        {
            StockEntity stockEntity = converterFactory.stockEntityConverter.Convert(stock);
            stockEntityDAO.Modify(stockEntity);
        }

        public void Remove(int id)
        {
            stockEntityDAO.Remove(id);
        }

        public Stock CreateNew()
        {
            return new Stock(-1, null, 0);
        }
    }
}