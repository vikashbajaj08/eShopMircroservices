using Catalog.Application.Commands.AddProduct;
using Catalog.Application.Commands.DeleteProduct;
using Catalog.Application.Commands.UpdateProduct;
using Catalog.Application.Queries.GetAllProducts;
using Catalog.Application.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Get Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var query = new GetProductQuery();

            var results = await mediator.Send(query);

            return Ok(results.Products);
        }
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProductByIdAsync(int ProductId)
        {
            var query = new GetProductByIdQuery(ProductId);
            var response = await mediator.Send(query);

            return Ok(response);


        }
        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] AddProductCommand command)
        {
            var response = await mediator.Send(command);

            if (!response.Success)
            {
                return BadRequest("Some error occured");
            }
            return Ok();
        }
        /// <summary>
        /// Delete Product 
        /// </summary>
        /// <param name="delete"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync([FromBody] DeleteProductCommand delete)
        {
            var response = await mediator.Send(delete);

            if (!response.Success)
            {
                return BadRequest("Some error occurred");
            }
            return Ok();
        }
        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand update)
        {
            var response = await mediator.Send(update);

            if (!response.Success)
            {
                return BadRequest("Some error occurred");
            }
            return Ok();
        }
    }
}
