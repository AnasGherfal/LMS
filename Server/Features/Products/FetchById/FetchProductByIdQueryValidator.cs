using Common.Validator;
using FluentValidation;

namespace Server.Features.Products.FetchById;

public class FetchProductByIdQueryValidator : AbstractValidator<FetchProductByIdQuery>
{
    public FetchProductByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
    }
}
