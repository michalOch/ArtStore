using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtStore.Data
{
    public class DutchContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
