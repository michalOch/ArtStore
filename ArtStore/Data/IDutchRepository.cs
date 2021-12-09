using ArtStore.Data.Entities;
using System.Collections.Generic;

namespace ArtStore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}