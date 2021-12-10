using ArtStore.Data.Entities;
using System.Collections.Generic;

namespace ArtStore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);

        bool SaveAll();
    }
}