using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Repository.IRepository;

namespace RST_WebApi.Repository
{
    public class AppetizeRepository : Repository<Appetize>, IAppetizeRepository
    {
        private readonly ApplicationDbContext _db;
        public AppetizeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public async Task<Appetize> UpdateAsync(Appetize entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Appetizes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
   
    }
}