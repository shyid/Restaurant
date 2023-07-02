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

namespace RST_WebApi.Controllers
{
    [Route("api/FoodApi")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IFoodRepository _dbFood;
        private readonly IMapper _mapper;
        public FoodController(IFoodRepository dbFood,IMapper mapper)
        {
            _dbFood = dbFood;
            _mapper = mapper;
            this._response = new();
        }

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetFoods(){
            try{
                IEnumerable<Food> FoodList = await _dbFood.GetAllAsync();
                _response.Result = _mapper.Map<List<FoodDTO>>(FoodList);
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
        [HttpGet("{id:int}",Name="GetFoods")]
        // [ProducesResponseType(StatusCode.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetFoods(int? id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var Foods = await _dbFood.GetAsync(u=>u.Id == id);
                if(Foods == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<FoodDTO>(Foods);
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateFood([FromBody]Food DtoFood){
            try{

                if(DtoFood == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                Food food = _mapper.Map<Food>(DtoFood);

                await _dbFood.CreateAsync(food);

                _response.Result = _mapper.Map<FoodDTO>(food);
                _response.StatusCode = HttpStatusCode.Created;
            
                return CreatedAtRoute("GetFoods",new{id=food.Id} , _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteFood(int id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var Foods = await _dbFood.GetAsync(u=>u.Id == id);
                if(Foods == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _dbFood.RemoveAsync(Foods);
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
        [HttpPut("{id:int}",Name="UpdateFood")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateFood(int id,Food DtoFood){
            try{
                if(id != DtoFood.Id || DtoFood== null) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                Food model = _mapper.Map<Food>(DtoFood);
                await _dbFood.UpdateAsync(model);
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
        [HttpPatch("{id:int}",Name="UpdatePartialFood")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePartialFood(int id ,JsonPatchDocument<FoodDTO> PatchDto){
            if(id ==0 || PatchDto== null) return BadRequest();
            var Foods = await _dbFood.GetAsync(u=>u.Id == id , tracked:false);

            FoodDTO FoodDtoModel = _mapper.Map<FoodDTO>(Foods);  
            
            if(Foods == null) BadRequest();
            PatchDto.ApplyTo(FoodDtoModel , ModelState);
            Food model = _mapper.Map<Food>(FoodDtoModel);

            await _dbFood.UpdateAsync(model);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}