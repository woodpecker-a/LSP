using Autofac;
using LSP.API.Models;
using Microsoft.AspNetCore.Mvc;
using Structure.BusinessObject;

namespace LSP.API.Controllers
{
    [ApiController, Route("v3/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILifetimeScope scope, ILogger<ProductController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var model = _scope.Resolve<ProductModel>();
            return model.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            var model = _scope.Resolve<ProductModel>();
            return model.GetProduct(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProductModel model)
        {
            try
            {
                model.ResolveDependency(_scope);
                model.CreateProduct();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductModel model)
        {
            try
            {
                model.ResolveDependency(_scope);
                model.UpdateProduct();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't Edit Product");
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var model = _scope.Resolve<ProductModel>();
                model.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't Delete Product");
                return BadRequest();
            }
        }
    }
}
