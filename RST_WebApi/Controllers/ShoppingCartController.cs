using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RST_WebApi.Data;
using RST_WebApi.Models;

namespace RST_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ApplicationDbContext _db;
        public ShoppingCartController( ApplicationDbContext db)
        {
            _db = db;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetShoppingCart(string userId)
        {
            try
            {
                ShoppingCart shoppingCart;
                if (string.IsNullOrEmpty(userId))
                {
                    shoppingCart = new();
                }
                else
                {
                    shoppingCart= _db.shoppingCarts
                    .Include(u => u.CartItems).ThenInclude(u => u.foodItem)
                    .FirstOrDefault(u => u.UserId == userId);

                }
                if (shoppingCart.CartItems != null && shoppingCart.CartItems.Count > 0) {
                    shoppingCart.CartTotal = shoppingCart.CartItems.Sum(u => u.Quantity * u.foodItem.Rate);
                }
                _response.Result = shoppingCart;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> AddOrUpdateItemInCart(string userId, int foodItemId, int updateQuantityBy)
        {
            ShoppingCart shoppingCart = _db.shoppingCarts.Include(u=>u.CartItems).FirstOrDefault(u => u.UserId == userId);
            Food FoodItem = _db.Foods.FirstOrDefault(u => u.Id == foodItemId);
            if(FoodItem == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            if(shoppingCart==null && updateQuantityBy > 0)
            {
                //create a shopping cart & add cart item

                ShoppingCart newCart = new() { UserId = userId };
                await _db.shoppingCarts.AddAsync(newCart);
                await _db.SaveChangesAsync();

                CartItem newCartItem = new()
                {
                    FoodId = foodItemId,
                    Quantity = updateQuantityBy,
                    ShoppingCartId = newCart.Id,
                    foodItem=null
                };
                await _db.cartItems.AddAsync(newCartItem);
                await _db.SaveChangesAsync();
            }
            else
            {
                //shopping cart exists

                CartItem cartItemInCart = shoppingCart.CartItems.FirstOrDefault(u => u.FoodId == foodItemId);
                if(cartItemInCart == null)
                {
                    //item does not exist in current cart
                    CartItem newCartItem = new()
                    {
                        FoodId = foodItemId,
                        Quantity = updateQuantityBy,
                        ShoppingCartId = shoppingCart.Id,
                        foodItem = null
                    };
                    await _db.cartItems.AddAsync(newCartItem);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    //item already exist in the cart and we have to update quantity
                    int newQuantity = cartItemInCart.Quantity + updateQuantityBy;
                    if(updateQuantityBy==0 || newQuantity <= 0)
                    {
                        //remove cart item from cart and if it is the only item then remove cart
                        _db.cartItems.Remove(cartItemInCart);
                        if (shoppingCart.CartItems.Count() == 1)
                        {
                            _db.shoppingCarts.Remove(shoppingCart);
                        }
                        await _db.SaveChangesAsync();
                    }
                    else
                    {
                        cartItemInCart.Quantity= newQuantity;
                        await _db.SaveChangesAsync();
                    }
                }
            }
            return _response;

        }
    

    }
}