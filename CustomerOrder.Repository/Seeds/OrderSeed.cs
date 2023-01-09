using CustomerOrder.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerOrder.Repository.Seeds
{
    internal class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(new Order
            {
                Id = 1,
                CustomerId = 1,
                OrderNumber = 1254,
                OrderDate = DateTime.Now,
                CreatedDate = DateTime.Now
            },
            new Order
            {
                Id = 2,
                CustomerId = 1,
                OrderNumber = 845,
                OrderDate = DateTime.Now,
                CreatedDate = DateTime.Now
            },
            new Order
            {
                Id =3,
                CustomerId = 2,
                OrderNumber = 365,
                OrderDate = DateTime.Now,
                CreatedDate = DateTime.Now
            },
            new Order
            {
                Id = 4,
                CustomerId = 1,
                OrderNumber = 254,
                OrderDate = DateTime.Now,
                CreatedDate = DateTime.Now
            },
            new Order
            {
                Id = 5,
                CustomerId = 2,
                OrderNumber = 124,
                OrderDate = DateTime.Now,
                CreatedDate = DateTime.Now
            });
        }
    }
}
