using Catalog.Application.Dtos;
using FluentValidation;
using MediatR;

namespace Catalog.Application.Commands.UpdateProduct
{
    public record UpdateProductCommand (ProductDto Product) : IRequest<UpdateProductCommandResult>;

    public record UpdateProductCommandResult(bool Success);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p=>p.Product.Name).NotEmpty().WithMessage("Product Name id required");
            RuleFor(p => p.Product.Description).NotEmpty().WithMessage("Product Description is required");
            RuleFor(p => p.Product.UnitPrice).GreaterThan(0).WithMessage("Product price must be greater than zero");
        }
    }
    
}
