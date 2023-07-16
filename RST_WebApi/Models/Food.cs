using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RST_WebApi.Models
{
    public class Food 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Ctegory ctegory {get;set;} = Ctegory.FastFood;
        [Required]
        public string Name { get; set; }
        public string? Details { get; set; }
        public double Rate { get; set; }
        public string? ImageUrl { get; set; }
        public EVStatus EVStatus {get;set;} 
        public bool Hidden {get;set;} = false ;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        // [NotMapped]
        // [FromForm]
        // public IFormFile File { get; set; }
        
    }
}