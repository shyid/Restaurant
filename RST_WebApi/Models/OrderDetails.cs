using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderHeaderId { get; set; }
        [Required]
        public int FoodId { get; set; }
        [ForeignKey("FoodId")]
        public Food foodItem { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public double Price { get; set; }
    }
}