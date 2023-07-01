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

namespace RST_WebApi.Controllers
{
    [Route("api/FoodApi")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public FoodController(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDTO>>> GetFoods(){
            IEnumerable<Food> FoodList = await _db.Foods.ToListAsync();
            return  Ok(_mapper.Map<List<FoodDTO>>(FoodList));
            
        }
        [HttpGet("{id:int}",Name="GetFoods")]
        // [ProducesResponseType(StatusCode.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FoodDTO>> GetFoods(int? id){
            if(id==0) return BadRequest();
            var Foods = await _db.Foods.FirstOrDefaultAsync(u=>u.Id == id);
            if(Foods == null) return NotFound();
            return Ok(_mapper.Map<FoodDTO>(Foods));
            
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FoodDTO>> CreateFood(Food DtoFood){

            if(DtoFood == null) return NotFound();

            Food model = _mapper.Map<Food>(DtoFood);

            await _db.Foods.AddAsync(model);
            await _db.SaveChangesAsync();


            return CreatedAtRoute("GetFoods",new{id=model.Id} , model);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteFood(int id){
            if(id==0) return BadRequest();
            var Foods = await _db.Foods.FirstOrDefaultAsync(u=>u.Id == id);
            if(Foods == null) return NotFound();
            _db.Foods.Remove(Foods);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}",Name="UpdateFood")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFood(int id,Food DtoFood){
            if(id != DtoFood.Id || DtoFood== null) return BadRequest();

            Food model = _mapper.Map<Food>(DtoFood);
            _db.Foods.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch("{id:int}",Name="UpdatePartialFood")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialFood(int id ,JsonPatchDocument<FoodDTO> PatchDto){
            if(id ==0 || PatchDto== null) return BadRequest();
            var Foods = await _db.Foods.AsNoTracking().FirstOrDefaultAsync(u=>u.Id == id);

            FoodDTO FoodDtoModel = _mapper.Map<FoodDTO>(Foods);  
            
            if(Foods == null) BadRequest();
            PatchDto.ApplyTo(FoodDtoModel , ModelState);
            Food model = _mapper.Map<Food>(FoodDtoModel);

          

            _db.Foods.Update(model);
            await _db.SaveChangesAsync();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}