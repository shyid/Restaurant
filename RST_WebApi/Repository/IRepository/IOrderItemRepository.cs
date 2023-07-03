using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RST_WebApi.Models;

namespace RST_WebApi.Repository.IRepository
{
    public interface IOrderItemRepository: IRepository<OrderItem>
    {
        // Task<List<OrderItem>> GetAllAsync(Expression<Func<OrderItem, bool>>? filter = null, string? includeProperties = null, int pageSize = 0, int pageNumber = 1);
        Task<OrderItem> UpdateAsync(OrderItem entity);
    }
}