using Entities;

namespace Services
{
    public interface IOrderServies
    {
        Task<OrdersTbl> addOrderToDB(OrdersTbl order);
        Task<IEnumerable<OrdersTbl>> GetOrdersAsync();
    }
}