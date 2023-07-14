using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models.Dto
{
    public class OrderDetailsCreateDTO
    {
        
        [Required]
        public int FoodId { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}