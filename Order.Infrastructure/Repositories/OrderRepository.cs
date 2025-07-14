using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;
using Order.Domain.Interfaces;
using Order.Infrastructure.Data;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<OrderModel> AddAsync(OrderModel order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrderModel?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
