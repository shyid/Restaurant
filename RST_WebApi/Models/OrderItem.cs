using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int Amount { get; set; }
        public double Price { get; set; }


        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("Food")]
        public int IdFood { get; set; }
        public Food? Food { get; set; }

        [ForeignKey("Drink")]
        public int IdDrink { get; set; }
        public Drink? Drink { get; set; }

        [ForeignKey("Appetize")]
        public int IdAppetize { get; set; }
        public Appetize? Appetize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}