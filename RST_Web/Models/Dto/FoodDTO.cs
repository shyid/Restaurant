using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RST_Web.Models.Dto
{
    public class FoodDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        
        public string Name { get; set; }
        public string? Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [DisplayName("ImageFile")]
        public string ImageUrl { get; set; } =string.Empty;
        // public IFormFile File { get; set; }
        // [NotMapped]
        // [DisplayName("ImageFile")]
        public EVStatus EVStatus {get;set;} 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        
    }
}