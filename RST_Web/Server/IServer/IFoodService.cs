using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_Web.Models.Dto;

namespace RST_Web.Server.IServer
{
    public interface IFoodService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id,string token);
        Task<T> CreateAsync<T>(FoodDTO dto,string token );
        Task<T> UpdateAsync<T>(FoodDTO dto ,string token);
        Task<T> DeleteAsync<T>(int id ,string token);
    }
}