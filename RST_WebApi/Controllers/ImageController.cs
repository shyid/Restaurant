using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RST_WebApi.Models;
using RST_WebApi.Models.Dto;
using RST_WebApi.Repository.IRepository;

namespace RST_WebApi.Controllers
{
    [ApiController]
    [Route("api/imageApi")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _dbImage;
         protected APIResponse _response;
        private readonly IMapper _mapper;
        

        public ImageController(IImageRepository dbImage,IMapper mapper)
        {
            _dbImage = dbImage;
            _mapper = mapper;
            this._response = new();
        }


        // POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageFileDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // convert DTO to Domain model
                // ImageFile image = _mapper.Map<ImageFile>(request);
                var imageDomainModel = new ImageFile
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName
                };
                

                // await _dbImage.CreateAsync(image);

                // _response.Result = _mapper.Map<ImageFile>(image);
                // _response.StatusCode = HttpStatusCode.Created;
            
                 // var imageDomainModel = new ImageFile
                // {
                //     File = request.File,
                //     FileExtension = Path.GetExtension(request.File.FileName),
                //     FileSizeInBytes = request.File.Length,
                //     FileName = request.FileName
                // };


                // User repository to upload image
                await _dbImage.Upload(imageDomainModel);

                return Ok(imageDomainModel);
                // return CreatedAtRoute("GetFoods",new{id=image.Id} , _response);
               

            }

            return BadRequest(ModelState);
        }


        private void ValidateFileUpload(ImageFileDTO request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file.");
            }
        }
    }
}