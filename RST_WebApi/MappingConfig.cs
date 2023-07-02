using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using RST_WebApi.Models;
using RST_WebApi.Models.Dto;

namespace RST_WebApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Food, FoodDTO>().ReverseMap();
            CreateMap<Drink, DrinkDTO>().ReverseMap();
            CreateMap<Appetize, AppetizeDTO>().ReverseMap();

        }
    
        
    }
}