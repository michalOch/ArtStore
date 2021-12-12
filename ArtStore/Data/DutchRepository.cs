using ArtStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtStore.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext _context;
        private readonly ILogger _logger;

        public DutchRepository(DutchContext context, ILogger<IDutchRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get all products was called");
                return _context.Products
                    .OrderBy(p => p.Title)
                    .ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _context.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return _context.Orders
                                .Include(o => o.Items)
                                .ThenInclude(i => i.Product)
                                .ToList();
                }
                else
                {
                    return _context.Orders
                                .ToList();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            try
            {
                if (includeItems)
                {
                    return _context.Orders
                                .Where(o => o.User.UserName == username)
                                .Include(o => o.Items)
                                .ThenInclude(i => i.Product)
                                .ToList();
                }
                else
                {
                    return _context.Orders
                                .Where(o => o.User.UserName == username)
                                .ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all orders: {ex}");
                return null;
            }
        }

        public Order GetOrderById(string userName, int id)
        {
            return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                    .Where(o => o.Id == id && o.User.UserName == userName)
                    .FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }
    }
}
