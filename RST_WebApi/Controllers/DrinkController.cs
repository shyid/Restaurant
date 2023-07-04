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
    [Route("api/DrinkApi")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IDrinkRepository _dbDrink;
        private readonly IMapper _mapper;
        public DrinkController(IDrinkRepository dbDrink,IMapper mapper)
        {
            _dbDrink = dbDrink;
            _mapper = mapper;
            this._response = new();
        }

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetDrinks(){
            try{
                IEnumerable<Drink> DrinkList = await _dbDrink.GetAllAsync();
                _response.Result = _mapper.Map<List<DrinkDTO>>(DrinkList);
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
        [HttpGet("{id:int}",Name="GetDrinks")]
        // [ProducesResponseType(StatusCode.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetDrinks(int? id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var Drinks = await _dbDrink.GetAsync(u=>u.Id == id);
                if(Drinks == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<DrinkDTO>(Drinks);
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
        public async Task<ActionResult<APIResponse>> CreateDrink([FromBody]Drink DtoDrink){
            try{

                if(DtoDrink == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                Drink Drink = _mapper.Map<Drink>(DtoDrink);

                await _dbDrink.CreateAsync(Drink);

                _response.Result = _mapper.Map<DrinkDTO>(Drink);
                _response.StatusCode = HttpStatusCode.Created;
            
                return CreatedAtRoute("GetDrinks",new{id=Drink.Id} , _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteDrink")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<APIResponse>> DeleteDrink(int id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var Drinks = await _dbDrink.GetAsync(u=>u.Id == id);
                if(Drinks == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _dbDrink.RemoveAsync(Drinks);
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
        [HttpPut("{id:int}",Name="UpdateDrink")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateDrink(int id,Drink DtoDrink){
            try{
                if(id != DtoDrink.Id || DtoDrink== null) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Drink model = _mapper.Map<Drink>(DtoDrink);
                await _dbDrink.UpdateAsync(model);
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
        [HttpPatch("{id:int}",Name="UpdatePartialDrink")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePartialDrink(int id ,JsonPatchDocument<DrinkDTO> PatchDto){
            if(id ==0 || PatchDto== null) return BadRequest();
            var Drinks = await _dbDrink.GetAsync(u=>u.Id == id , tracked:false);

            DrinkDTO DrinkDtoModel = _mapper.Map<DrinkDTO>(Drinks);  
            
            if(Drinks == null) BadRequest();
            PatchDto.ApplyTo(DrinkDtoModel , ModelState);
            Drink model = _mapper.Map<Drink>(DrinkDtoModel);

            await _dbDrink.UpdateAsync(model);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}