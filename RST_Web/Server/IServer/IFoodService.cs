using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_Web.Models.Dto;

namespace RST_Web.Server.IServer
{
    public interface IFoodService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(FoodDTO dto );
        Task<T> UpdateAsync<T>(FoodDTO dto );
        Task<T> DeleteAsync<T>(int id );
    }
}