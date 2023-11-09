using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Store214358897Context _store214358897Context;

        public OrderRepository(Store214358897Context store214358897Context)
        {
            _store214358897Context = store214358897Context;
        }

        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {
            await _store214358897Context.OrdersTbls.AddAsync(order);
            await _store214358897Context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _store214358897Context.OrdersTbls.ToListAsync();
        }
    }
}
