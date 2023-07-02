using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Repository.IRepository;

namespace RST_WebApi.Repository
{
    public class DrinkRepository : Repository<Drink>, IDrinkRepository
    {
        private readonly ApplicationDbContext _db;
        public DrinkRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public async Task<Drink> UpdateAsync(Drink entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Drinks.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}