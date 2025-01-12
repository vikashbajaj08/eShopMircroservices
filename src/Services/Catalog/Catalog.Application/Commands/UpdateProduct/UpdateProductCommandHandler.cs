using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Interface;
using FluentValidation;
using MediatR;

namespace Catalog.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository repository,
        IMapper mapper) : IRequestHandler<UpdateProductCommand, UpdateProductCommandResult>
    {
        public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            
            var product = mapper.Map<Product>(request);

            await repository.Update(product);

            return new UpdateProductCommandResult(true);
        }
    }
}
