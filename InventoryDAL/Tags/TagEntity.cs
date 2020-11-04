﻿using System.Collections.Generic;
using InventoryLogic.Tags;
using InventoryDAL.ProductTagJoins;
using InventoryLogic.Facade;
using InventoryDAL.Database;
using InventoryDAL.Products;

namespace InventoryDAL.Tags
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductTagJoinEntity> ProductTagJoinEntities { get; set; }

        public TagEntity()
        {
        }
    }
}
