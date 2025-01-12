using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Interface;
using FluentValidation;
using MediatR;

namespace Catalog.Application.Commands.AddProduct
{
    public class AddProductCommandHandler(IProductRepository repository,
        IMapper mapper) : IRequestHandler<AddProductCommand, AddProductCommandResult>
    {
        public async Task<AddProductCommandResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
          
            var product = mapper.Map<Product>(request.Product);
            await repository.Add(product);

            return new AddProductCommandResult(true);
        }
    }
}
