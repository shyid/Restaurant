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
        public async Task UploadImage(Food entity , int lastId)
        {
        //    var lastId= _db.Foods.Max(u=>u.Id) +1;
            
            entity.ImageUrl = Path.Combine(@"C:\Users\asus\Desktop\Restaurant\RST_WebApi\Images", 
                $"{lastId}{entity.FileName}{Path.GetExtension(entity.File.FileName)}");
            // Upload Image to Local Path
            using var stream = new FileStream(entity.ImageUrl, FileMode.Create);
            await entity.File.CopyToAsync(stream);

            // await CreateAsync(entity);
            //for send image:path+id+nameimage+extension

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