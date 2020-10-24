﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using InventoryLogic.Products;
using InventoryLogic.ProductTags;
using InventoryLogic.Stocks;

namespace InventoryDAL.Database
{
    public class MySqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // use docker composer mysql credentials (safe to store in code)
            optionsBuilder.UseMySQL("server=db;port=3306;userid=dbuser;password=dbuserpassword;database=accountowner;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryLogic.Products.Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Sku).IsRequired();
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<InventoryLogic.Stocks.Stock>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Productname).IsRequired();
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.Today).IsRequired();
            });
        }
    }
}
