using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServies : IOrderServies
    {
        IOrderRepository _orderRepository;

        public OrderServies(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrdersTbl> addOrderToDB(OrdersTbl order)
        {

            return await _orderRepository.addOrderToDB(order);
        }

        public async Task<IEnumerable<OrdersTbl>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}
