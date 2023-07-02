using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_WebApi.Models;

namespace RST_WebApi.Repository.IRepository
{
    public interface IDrinkRepository : IRepository<Drink>
    {
        Task<Drink> UpdateAsync(Drink entity);
     
    }
}