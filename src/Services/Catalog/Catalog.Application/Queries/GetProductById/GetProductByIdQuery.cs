using Catalog.Application.Dtos;
using FluentValidation;
using MediatR;

namespace Catalog.Application.Queries.GetProductById
{
    public record GetProductByIdQuery(int ProductId) : IRequest<GetProductByIdQueryResult>;

    public record GetProductByIdQueryResult(ProductDto Product);

    public class GetProductByIdQueryValidator:AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(p=>p.ProductId).NotEmpty().WithMessage("Product Id is required");
        }
    }
    
}
