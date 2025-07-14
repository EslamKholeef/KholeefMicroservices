using Order.Domain.Entities;

namespace Order.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderModel> AddAsync(OrderModel order);
        Task<OrderModel?> GetByIdAsync(int id);
    }
}
