using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using RST_WebApi.Models;

namespace RST_WebApi.Repository.IRepository
{
    public interface IImageRepository : IRepository<ImageFile>
    {
        Task<ImageFile> Upload(ImageFile imageFile);
    }
}