using ArtStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ArtStore.Data
{
    public class DutchContext : DbContext
    {
        public DutchContext(DbContextOptions<DutchContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
