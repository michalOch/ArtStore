﻿using System.ComponentModel.DataAnnotations;

namespace ArtStore.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}