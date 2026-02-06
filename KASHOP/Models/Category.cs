using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace KASHOP.Models
{
    public class Category
    {
        public int Id {get; set;}

        [Column("varchar(50)")]
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name {get; set;}
        [ValidateNever]
        public List<Product> Products {get; set;}
    }
}