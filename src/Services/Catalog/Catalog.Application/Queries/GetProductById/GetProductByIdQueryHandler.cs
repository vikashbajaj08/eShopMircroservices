using AutoMapper;
using Catalog.Application.Dtos;
using Catalog.Domain.Interface;
using MediatR;

namespace Catalog.Application.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler (IProductRepository repository,
        IMapper mapper) : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
          

           var result = await repository.GetById(request.ProductId);

           var product = mapper.Map<ProductDto>(result);

            return new GetProductByIdQueryResult(product);

        }
    }
}
