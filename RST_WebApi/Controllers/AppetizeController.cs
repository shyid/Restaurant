using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Models.Dto;
using RST_WebApi.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace RST_WebApi.Controllers
{
    [Route("api/AppetizeApi")]
    [ApiController]
    public class AppetizeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IAppetizeRepository _dbAppetize;
        private readonly IMapper _mapper;
        public AppetizeController(IAppetizeRepository dbAppetize,IMapper mapper)
        {
            _dbAppetize = dbAppetize;
            _mapper = mapper;
            this._response = new();
        }

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAppetizes(){
            try{
                IEnumerable<Appetize> AppetizeList = await _dbAppetize.GetAllAsync();
                List<Appetize> listresult = new List <Appetize> ();
                foreach(var f in AppetizeList){
                    if(f.Hidden){
                        continue;
                    }
                    listresult.Add(f);
                }
                _response.Result = _mapper.Map<List<AppetizeDTO>>(listresult);
                _response.StatusCode = HttpStatusCode.OK;
                return  Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
            
        }
        [HttpGet("{id:int}",Name="GetAppetizes")]
        // [ProducesResponseType(StatusCode.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAppetizes(int? id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var Appetize = await _dbAppetize.GetAsync(u=>u.Id == id);
                if(Appetize == null || Appetize.Hidden) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<AppetizeDTO>(Appetize);
                _response.StatusCode = HttpStatusCode.OK;
                return  Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
            
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateAppetize([FromBody]Appetize DtoAppetize){
            try{

                if(DtoAppetize == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                Appetize Appetize = _mapper.Map<Appetize>(DtoAppetize);
                if(Appetize.ImageUrl is not null)
                    await _dbAppetize.ConvertTobase64(Appetize.ImageUrl);
                await _dbAppetize.CreateAsync(Appetize);

                _response.Result = _mapper.Map<AppetizeDTO>(Appetize);
                _response.StatusCode = HttpStatusCode.Created;
            
                return CreatedAtRoute("GetAppetizes",new{id=Appetize.Id} , _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id:int}", Name = "DeleteAppetize")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteAppetize(int id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var Appetizes = await _dbAppetize.GetAsync(u=>u.Id == id);
                if(Appetizes == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                Appetizes.Hidden = true;
                await _dbAppetize.SaveAsync();
                // await _dbAppetize.RemoveAsync(Appetizes);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}",Name="UpdateAppetize")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAppetize(int id,Appetize DtoAppetize){
            try{
                if(id != DtoAppetize.Id || DtoAppetize== null) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Appetize model = _mapper.Map<Appetize>(DtoAppetize);
                if(model.ImageUrl is not null)
                    await _dbAppetize.ConvertTobase64(model.ImageUrl,model.Id);
                await _dbAppetize.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPatch("{id:int}",Name="UpdatePartialAppetize")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePartialAppetize(int id ,JsonPatchDocument<AppetizeDTO> PatchDto){
            if(id ==0 || PatchDto== null) return BadRequest();
            var Appetizes = await _dbAppetize.GetAsync(u=>u.Id == id , tracked:false);

            AppetizeDTO AppetizeDtoModel = _mapper.Map<AppetizeDTO>(Appetizes);  
            
            if(Appetizes == null) BadRequest();
            PatchDto.ApplyTo(AppetizeDtoModel , ModelState);
            Appetize model = _mapper.Map<Appetize>(AppetizeDtoModel);

            await _dbAppetize.UpdateAsync(model);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}