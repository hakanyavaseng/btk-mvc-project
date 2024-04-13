using Entities.Models;

namespace Repositories.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> Orders { get; }
        Order? GetOrder(int id);
        void Complete(int id);
        Task SaveOrder(Order order);
        int NumberOfInProcessOrders();
    }
}
