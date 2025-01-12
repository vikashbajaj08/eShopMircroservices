using AutoMapper;
using Catalog.Domain.Interface;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
