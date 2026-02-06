using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KASHOP.Models
{
    public class Category
    {
        public int Id {get; set;}

        [Column("varchar(50)")]
        public string Name {get; set;}
    }
}