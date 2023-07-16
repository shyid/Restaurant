using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RST_WebApi.Models.Dto
{
    // dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore   
    // dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson 
    public class FoodDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        
        public string Name { get; set; }
        public Category category {get;set;} = Category.FastFood;
        public string? Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public string? ImageUrl { get; set; }
        public EVStatus EVStatus {get;set;} 
        // [NotMapped]
        // [FromForm]
        // public IFormFile File { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Hidden {get;set;} = false ;
        
    }
}