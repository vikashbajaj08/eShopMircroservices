using Catalog.Application.Dtos;
using MediatR;

namespace Catalog.Application.Queries.GetAllProducts
{
    public record GetProductQuery() :IRequest<GetProductQueryResult>;

    public record GetProductQueryResult(IEnumerable<ProductDto> Products);
    
}
