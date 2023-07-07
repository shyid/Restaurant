using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RST_WebApi.Models.Dto
{
    public class ShoppingCartItemDTO
    {
        [Key]
        public int Id { get; set; }

        public Food food { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }

        
    }
}