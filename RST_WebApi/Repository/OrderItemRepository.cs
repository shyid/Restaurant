using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RST_WebApi.Data;
using RST_WebApi.Models;
using RST_WebApi.Repository.IRepository;

namespace RST_WebApi.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderItemRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
    //    public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
    //     {
    //         var order = new Order()
    //         {
    //             UserId = userId,
    //             Email = userEmailAddress
    //         };
    //         await _context.Orders.AddAsync(order);
    //         await _context.SaveChangesAsync();

    //         foreach (var item in items)
    //         {
    //             var orderItem = new OrderItem()
    //             {
    //                 Amount = item.Amount,
    //                 MovieId = item.Movie.Id,
    //                 OrderId = order.Id,
    //                 Price = item.Movie.Price
    //             };
    //             await _context.OrderItems.AddAsync(orderItem);
    //         }
    //         await _context.SaveChangesAsync();
    //     }
        // public async Task<List<OrderItem>> GetAllAsync(Expression<Func<OrderItem, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int pageNumber = 1)
        // {
        //     //  IQueryable<Order> query = _db.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Food).ToListAsync();
        //     List<OrderItem> query;

        //     if (filter != null)
        //     {
        //         // query = query.Where(filter);
        //     //    query = await _db.Orders.Include(n=>n.OrderItems).ThenInclude(n=>n.Food).Where(filter).ToListAsync();
        //     }else{
        //     //    query = await _db.Orders.Include(n=>n.OrderItems).ThenInclude(n=>n.Food).ToListAsync();
        //     }
          
        //     return query;
            
        // }
       
        // public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        // {
        //     var order = new Order()
        //     {
        //         UserId = userId,
        //         Email = userEmailAddress
        //     };
        //     await _db.Orders.AddAsync(order);
        //     await _db.SaveChangesAsync();

        //     foreach (var item in items)
        //     {
        //         var orderItem = new OrderItem()
        //         {
        //             Amount = item.Amount,
        //             MovieId = item.Movie.Id,
        //             OrderId = order.Id,
        //             Price = item.Movie.Price
        //         };
        //         await _db.orderItems.AddAsync(orderItem);
        //     }
        //     await _db.SaveChangesAsync();
        // }
        public async Task<OrderItem> UpdateAsync(OrderItem entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.OrderItems.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        
    }
}