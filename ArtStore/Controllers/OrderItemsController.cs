using ArtStore.Data;
using ArtStore.Data.Entities;
using ArtStore.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtStore.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class OrderItemsController : Controller
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IDutchRepository repository, ILogger<OrderItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            try
            {
                var username = User.Identity.Name;
                var order = _repository.GetOrderById(username, orderId);
                if (order != null)
                {
                    return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order items: {ex}");
                return BadRequest($"Failed to get order items");
            }
        }

        // "/api/orders/{orderid}/items/{id}"
        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            try
            {
                var order = _repository.GetOrderById(User.Identity.Name,orderId);
                if (order != null)
                {
                    var item = order.Items.Where(i => id == i.Id).FirstOrDefault();
                    if(item != null)
                    {
                        return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(item));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get order items: {ex}");
                return BadRequest($"Failed to get order items");
            }
        }
    }
}
