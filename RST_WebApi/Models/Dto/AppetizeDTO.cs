using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models.Dto
{
    public class AppetizeDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        public FoodStatus FoodStatus {get;set;} 
        
        
    }
}