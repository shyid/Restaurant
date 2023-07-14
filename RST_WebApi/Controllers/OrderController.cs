using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Models.Dto;

namespace RST_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ApplicationDbContext _db;
        public OrderController( ApplicationDbContext db)
        {
            _db = db;
            this._response = new();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetOrders(string? userId
        /*,string searchString, string status, int pageNumber =1, int pageSize=5*/)
        {
            try
            {
                IEnumerable<OrderHeader> orderHeaders =
                    _db.orderHeaders.Include(u => u.OrderDetails)
                    .ThenInclude(u => u.foodItem)
                    .OrderByDescending(u => u.OrderHeaderId);

                if (!string.IsNullOrEmpty(userId)){
                    orderHeaders = orderHeaders.Where(u => u.ApplicationUserId == userId);
                }

                // if (!string.IsNullOrEmpty(searchString))
                // {
                //     orderHeaders = orderHeaders
                //         .Where(u => u.PickupPhoneNumber.ToLower().Contains(searchString.ToLower()) ||
                //     u.PickupEmail.ToLower().Contains(searchString.ToLower()) 
                //     || u.PickupName.ToLower().Contains(searchString.ToLower()));
                // }
                // if (!string.IsNullOrEmpty(status))
                // {
                //     orderHeaders = orderHeaders.Where(u => u.Status.ToLower() == status.ToLower());
                // }

                // Pagination pagination = new()
                // {
                //     CurrentPage = pageNumber,
                //     PageSize = pageSize,
                //     TotalRecords = orderHeaders.Count(),
                // };

                // Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagination));

                // _response.Result = orderHeaders.Skip((pageNumber-1)*pageSize).Take(pageSize);
                _response.Result = orderHeaders;
                _response.StatusCode = HttpStatusCode.OK;
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<APIResponse>> GetOrders(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var orderHeaders = _db.orderHeaders.Include(u => u.OrderDetails)
                    .ThenInclude(u => u.foodItem)
                    .Where(u => u.OrderHeaderId==id);
                if (orderHeaders == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = orderHeaders;
                _response.StatusCode = HttpStatusCode.OK;
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

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateOrder([FromBody] OrderHeaderCreateDTO orderHeaderDTO)
        {
            try
            {
                OrderHeader order = new()
                {
                    ApplicationUserId = orderHeaderDTO.ApplicationUserId,
                    PickupEmail = orderHeaderDTO.PickupEmail,
                    PickupName = orderHeaderDTO.PickupName,
                    PickupPhoneNumber = orderHeaderDTO.PickupPhoneNumber,
                    OrderTotal = orderHeaderDTO.OrderTotal,
                    OrderDate = DateTime.Now,
                    StripePaymentIntentID = orderHeaderDTO.StripePaymentIntentID,
                    TotalItems = orderHeaderDTO.TotalItems,
                    Status= String.IsNullOrEmpty(orderHeaderDTO.Status)? "pending" : orderHeaderDTO.Status,
                };

                if (ModelState.IsValid)
                {
                    await _db.orderHeaders.AddAsync(order);
                    await _db.SaveChangesAsync();
                    foreach(var orderDetailDTO in orderHeaderDTO.OrderDetailsDTO)
                    {
                        OrderDetails orderDetails = new()
                        {
                            OrderHeaderId = order.OrderHeaderId,
                            FoodName = orderDetailDTO.FoodName,
                            FoodId = orderDetailDTO.FoodId,
                            Price = orderDetailDTO.Price,
                            Quantity = orderDetailDTO.Quantity,
                        };
                        await _db.orderDetails.AddAsync(orderDetails);
                    }
                    await _db.SaveChangesAsync();
                    _response.Result = order;
                    order.OrderDetails = null;
                    _response.StatusCode = HttpStatusCode.Created;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> UpdateOrderHeader(int id, [FromBody] OrderHeaderUpdateDTO orderHeaderUpdateDTO)
        {
            try
            {
                if (orderHeaderUpdateDTO == null || id != orderHeaderUpdateDTO.OrderHeaderId)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                OrderHeader orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.OrderHeaderId == id);

                if (orderFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupName))
                {
                    orderFromDb.PickupName = orderHeaderUpdateDTO.PickupName;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupPhoneNumber))
                {
                    orderFromDb.PickupPhoneNumber = orderHeaderUpdateDTO.PickupPhoneNumber;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.PickupEmail))
                {
                    orderFromDb.PickupEmail = orderHeaderUpdateDTO.PickupEmail;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.Status))
                {
                    orderFromDb.Status = orderHeaderUpdateDTO.Status;
                }
                if (!string.IsNullOrEmpty(orderHeaderUpdateDTO.StripePaymentIntentID))
                {
                    orderFromDb.StripePaymentIntentID = orderHeaderUpdateDTO.StripePaymentIntentID;
                }
                await _db.SaveChangesAsync();
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
         

    }
}