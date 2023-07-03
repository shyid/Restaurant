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
    [Route("api/OrderItemApi")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IOrderItemRepository _dbOrderItem;
        private readonly IMapper _mapper;
        public OrderItemController(IOrderItemRepository dbOrderItem,IMapper mapper)
        {
            _dbOrderItem = dbOrderItem;
            _mapper = mapper;
            this._response = new();
        }

        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetOrderItems(){
            try{
                IEnumerable<OrderItem> OrderList = await _dbOrderItem.GetAllAsync();
                _response.Result = _mapper.Map<List<OrderItemDTO>>(OrderList);
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
        [HttpGet("{id:int}",Name="GetOrderItems")]
        // [ProducesResponseType(StatusCode.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetOrderItems(int? id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var OrderItems = await _dbOrderItem.GetAsync(u=>u.Id == id);
                if(OrderItems == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<OrderItemDTO>(OrderItems);
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
        public async Task<ActionResult<APIResponse>> CreateOrderItem([FromBody]OrderItem DtoOrderItem){
            try{

                if(DtoOrderItem == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                OrderItem OrderItem = _mapper.Map<OrderItem>(DtoOrderItem);

                await _dbOrderItem.CreateAsync(OrderItem);

                _response.Result = _mapper.Map<OrderItemDTO>(OrderItem);
                _response.StatusCode = HttpStatusCode.Created;
            
                return CreatedAtRoute("GetOrderItems",new{id=OrderItem.Id} , _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}", Name = "DeleteOrderItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteOrderItem(int id){
            try{
                if(id==0) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var OrderItems = await _dbOrderItem.GetAsync(u=>u.Id == id);
                if(OrderItems == null) {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _dbOrderItem.RemoveAsync(OrderItems);
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
        [HttpPut("{id:int}",Name="UpdateOrderItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateOrderItem(int id,OrderItem DtoOrderItem){
            try{
                if(id != DtoOrderItem.Id || DtoOrderItem== null) {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                OrderItem model = _mapper.Map<OrderItem>(DtoOrderItem);
                await _dbOrderItem.UpdateAsync(model);
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
        [HttpPatch("{id:int}",Name="UpdatePartialOrderItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdatePartialOrderItem(int id ,JsonPatchDocument<OrderItemDTO> PatchDto){
            if(id ==0 || PatchDto== null) return BadRequest();
            var OrderItems = await _dbOrderItem.GetAsync(u=>u.Id == id , tracked:false);

            OrderItemDTO OrderItemDtoModel = _mapper.Map<OrderItemDTO>(OrderItems);  
            
            if(OrderItems == null) BadRequest();
            PatchDto.ApplyTo(OrderItemDtoModel , ModelState);
            OrderItem model = _mapper.Map<OrderItem>(OrderItemDtoModel);

            await _dbOrderItem.UpdateAsync(model);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}