using CustomerOrder.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Repository.Seeds
{
    internal class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, FirstName = "Elise", LastName = "Rick", Address = "London BT34FT" },
                new Customer { Id = 2, FirstName = "Jon", LastName = "Bon", Address = "Milton Keynes MK34FT" },
                new Customer { Id = 3, FirstName = "Andrea", LastName = "Bon", Address = "London SW34FT" }
                );
        }
    }
}
