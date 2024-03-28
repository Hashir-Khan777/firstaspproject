﻿using System.ComponentModel.DataAnnotations;

namespace firstaspapp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public List<Product>? Products { get; set; }
    }
}
