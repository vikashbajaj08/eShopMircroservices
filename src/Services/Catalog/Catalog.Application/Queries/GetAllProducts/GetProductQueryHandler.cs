using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Domain.Interface;
using MediatR;

namespace Catalog.Application.Queries.GetAllProducts
{
    public class GetProductQueryHandler(IProductRepository repository, 
        IMapper mapper) : IRequestHandler<GetProductQuery, GetProductQueryResult>
    {
        public async Task<GetProductQueryResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
          var result =  await repository.GetAll();

           var products = mapper.Map<IEnumerable<ProductDto>>(result);

            return new GetProductQueryResult(products);
        }
    }
}
