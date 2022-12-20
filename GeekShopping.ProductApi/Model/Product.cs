﻿using GeekShopping.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;

namespace GeekShopping.ProductApi.Model
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
