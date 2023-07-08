using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Repository.IRepository;

namespace RST_WebApi.Repository
{
    public class ImageRepository : Repository<ImageFile>, IImageRepository
    {
        private readonly ApplicationDbContext _db;
        public ImageRepository(IWebHostEnvironment environment ,ApplicationDbContext db): base(db)
        {
            
            _db = db;
        }
        public async Task<ImageFile> Upload(ImageFile imageFile)
        {
           var lastId= _db.imageFiles.Max(u=>u.Id);
           lastId ++;
            // var emps = from e in _db.imageFiles
            // orderby e.Id
            // select  e.max(Id);
            var localFilePath = Path.Combine(@"C:\Users\asus\Desktop\Restaurant\RST_WebApi\Images", 
                $"{lastId}{imageFile.FileName}{imageFile.FileExtension}");
            // Upload Image to Local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await imageFile.File.CopyToAsync(stream);

            // https://localhost:1234/images/image.jpg

            // var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            // image.FilePath = urlFilePath;

            await _db.imageFiles.AddAsync(imageFile);
            await _db.SaveChangesAsync();
            return imageFile;
        }
    }
}