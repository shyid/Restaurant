using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }
        

        public int OrderId { get; set; }
        

        public int IdFood { get; set; }

        public int IdDrink { get; set; }
        
        public int IdAppetize { get; set; }
    }
}