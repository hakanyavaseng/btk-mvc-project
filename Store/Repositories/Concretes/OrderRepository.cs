using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.Concretes
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<Order> Orders => _repositoryContext.Orders
            .Include(o => o.Lines)
            .ThenInclude(cl => cl.Product)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);
        public int NumberOfInProcessOrders() => _repositoryContext.Orders.Count(o => o.Shipped == false);

        public void Complete(int id)
        {
           var order = FindByCondition(o => o.OrderId == id, true).FirstOrDefault();
           if(order is null)
                throw new Exception("Order not found");
           order.Shipped = true;
        }
        public Order? GetOrder(int id) => FindByCondition(o => o.OrderId == id, false).FirstOrDefault();
        public async Task SaveOrder(Order order)
        {
            _repositoryContext.AttachRange(order.Lines.Select(l => l.Product));
            if(order.OrderId == 0)
                _repositoryContext.Add(order);
            await _repositoryContext.SaveChangesAsync();
           
        }
    }
}
