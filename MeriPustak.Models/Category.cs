﻿using System.ComponentModel.DataAnnotations;

namespace MeriPustak.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Diasplay Order must be between 1-100")]
        public int DiasplayOrder { get; set; }
    }
}
