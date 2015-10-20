﻿namespace Toys.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Sku { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime? Date { get; set; }

        public int SellerId { get; set; }

        public virtual Seller Seller { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
