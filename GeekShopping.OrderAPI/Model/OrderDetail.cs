﻿using GeekShopping.OrderAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.OrderAPI.Model
{
    [Table("order_detail")]
    public class OrderDetail : BaseEntity
    {
        public int OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }


        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}
