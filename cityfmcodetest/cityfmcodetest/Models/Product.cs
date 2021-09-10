using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cityfmcodetest.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int? MaximumQuantity { get; set; }
    }
}
