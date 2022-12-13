using Microsoft.EntityFrameworkCore;
using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.Model.Context;

namespace GeekShopping.OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<SqlContext> _context;

        public OrderRepository(DbContextOptions<SqlContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if (header == null) return false;
            await using var _db = new SqlContext(_context);
            _db.OrderHeaders.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid)
        {
            await using var _db = new SqlContext(_context);
            var header = await _db.OrderHeaders.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header != null)
            {
                header.PaymentStatus = paid;
                await _db.SaveChangesAsync();
            }
        }
    }
}
