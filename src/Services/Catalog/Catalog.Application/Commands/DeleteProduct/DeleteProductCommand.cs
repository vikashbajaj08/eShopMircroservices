using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands.DeleteProduct
{
    public record DeleteProductCommand(int ProductId) :IRequest<DeleteProductCommandResult>;

    public record DeleteProductCommandResult(bool Success);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product Id is required.");
        }
    }
}
