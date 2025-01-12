using Catalog.Application.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {
            var query = new GetProductQuery();

            var results = await mediator.Send(query);

            return Ok(results.Products);
        }
    }
}
