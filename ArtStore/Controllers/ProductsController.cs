using ArtStore.Data;
using ArtStore.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ArtStore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IDutchRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IDutchRepository repository, ILogger<ProductsController> logger )
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest($"Failed to get products");  
            }        
        }
    }
}
