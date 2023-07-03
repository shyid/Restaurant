using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using RST_Web.Models;
using RST_Web.Models.Dto;

namespace RST_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // CreateMap<Food, FoodDTO>().ReverseMap();
            // CreateMap<Drink, DrinkDTO>().ReverseMap();
            // CreateMap<Appetize, AppetizeDTO>().ReverseMap();
            // CreateMap<Order, OrderDTO>().ReverseMap();

        }
    
        
    }
}