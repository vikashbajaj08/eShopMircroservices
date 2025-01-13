using Catalog.Application.Dtos;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands.AddProduct
{

    public record AddProductCommand(ProductDto Product) : IRequest<AddProductCommandResult>;

    public record AddProductCommandResult(bool Success);

    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(p=>p.Product.Name).NotEmpty().WithMessage("Product Name is required");
            RuleFor(p => p.Product.UnitPrice).GreaterThan(0).WithMessage("Product price must be greater than 0");
        }
    }
    
}
