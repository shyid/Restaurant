using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Repository.IRepository;

namespace RST_WebApi.Repository
{
    public class FoodRepository : Repository<Food>, IFoodRepository
    {
        private readonly ApplicationDbContext _db;
        public FoodRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public async Task<Food> UpdateAsync(Food entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Foods.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}