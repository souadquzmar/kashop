using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace KASHOP.Models
{
    public class Product
    {
        public int Id {get; set;}
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Name {get; set;}
        [Range(0,10000)]
        public decimal Price {get; set;}
        public string Description {get; set;}
        public double Rate {get; set;}
        public string? Image {get; set;}
        public int CategoryId {get; set;}
        [ValidateNever]
        public Category Category {get; set;}

    }
}