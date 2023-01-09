using CustomerOrder.Core.Models;
using CustomerOrder.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Repository.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetOrdersWithCustomerAsync()
        {
            return await _context.Orders.Include(x => x.Customer).ToListAsync();
        }
    }
}
