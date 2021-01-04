﻿using InventoryLogic.Facade;
using InventoryLogic.Interfaces;
using InventoryLogic.Products;
using System.Collections.Generic;

namespace InventoryLogic.Tags
{
    public class TagDTO : IHasUniqueObjectId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }

        public TagDTO()
        {
            Products = new List<ProductDTO>();
        }
    }
}
