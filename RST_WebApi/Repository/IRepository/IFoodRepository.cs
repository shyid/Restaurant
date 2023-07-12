using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RST_WebApi.Models;

namespace RST_WebApi.Repository.IRepository
{
    public interface IFoodRepository : IRepository<Food>
    {
        // Task UploadImage(Food entity , int lastId = 0);
        Task<string> ConvertTobase64(string responseFile , int lastId=0);
        Task<Food> UpdateAsync(Food entity);
        
    }
}