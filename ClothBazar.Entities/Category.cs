﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Entities
{
    public class Category : BaseEntity
    {
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }

        public bool IsFeatured { get; set; }
    }
}
