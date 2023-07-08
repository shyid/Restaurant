using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models.Dto
{
    public class ImageFileDTO
    {
        

        [NotMapped]
        public IFormFile File { get; set; }

        public string FileName { get; set; }
        // public string? FileDescription { get; set; }
        
    }
}