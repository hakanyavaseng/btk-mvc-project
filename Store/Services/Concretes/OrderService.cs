using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;
        public async Task Complete(int id)
        {
            _manager.Order.Complete(id);
            await _manager.SaveAsync();

        }
        public Order? GetOrder(int id) => _manager.Order.GetOrder(id);
        public int NumberOfInProcessOrders() => _manager.Order.NumberOfInProcessOrders();
        public async Task SaveOrder(Order order) => await _manager.Order.SaveOrder(order);
    }
}
