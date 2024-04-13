using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }
        Order? GetOrder(int id);
        Task Complete(int id);
        Task SaveOrder(Order order);
        int NumberOfInProcessOrders();

    }
}
