﻿using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail : BaseEntity
    {
        public long CartHeaderId { get; set; }
        
        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }

        [ForeignKey("ProductId")]
        public long ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}
