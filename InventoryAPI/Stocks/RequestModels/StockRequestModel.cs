﻿using InventoryAPI.Products.RequestModels;
using InventoryLogic.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryAPI.Stocks.RequestModels
{
    public class StockRequestModel : StockRequestChildModel
    {
        public ProductRequestModel Product { get; set; }

        public StockRequestModel() : base()
        {

        }


        public static StockRequestModel StockDTOToStockRequestModel(StockDTO stock)
        {
            return new StockRequestModel()
            {
                Id = stock.Id,
                Amount = stock.Amount,
                ProductId = stock.ProductId,
                Product = stock.Product != null ? ProductRequestModel.ProductDTOToProductRequestModel(stock.Product) : null,
                Date = stock.Date
            };
        }

        // system converter
        public static StockDTO StockRequestModelToStockDTO(StockRequestModel stock)
        {
            return new StockDTO()
            {
                Id = stock.Id,
                Amount = stock.Amount,
                ProductId = stock.ProductId,
                //Product = ProductRequestModel.ProductDTOToProductRequestModel(stock.Product), error in logic layer TODO, stockDTO must contain ProductDTO, not Product
                Date = stock.Date
            };
        }

    }
}
