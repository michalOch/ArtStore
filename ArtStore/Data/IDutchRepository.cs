using ArtStore.Data.Entities;
using System.Collections.Generic;

namespace ArtStore.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
      
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string userName, int id);

        bool SaveAll();
        void AddEntity(object model);
    }
}