using Catalog.Domain.Interface;
using MediatR;

namespace Catalog.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand, DeleteProductCommandResult>
    {
        public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           
            await repository.Delete(request.ProductId);

            return new DeleteProductCommandResult(true);
        }
    }
}
