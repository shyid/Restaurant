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
        public async Task ConvertTobase64(string responseFile , int lastId=0)
        {
            if(lastId == 0){
                lastId= _db.Drinks.Max(u=>u.Id) +1;
            }
            var index = responseFile.IndexOf(',');
            responseFile = responseFile.Substring(index+1);
            byte[] bytes = Convert.FromBase64String(responseFile);
            await System.IO.File.WriteAllBytesAsync("images/"+lastId+".png" , bytes );
            
            // return responseFile;
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