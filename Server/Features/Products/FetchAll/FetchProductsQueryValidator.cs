using Common.Validator;
using FluentValidation;

namespace Server.Features.Products.FetchAll;

public class FetchProductsQueryValidator : AbstractValidator<FetchProductsQuery>
{
    public FetchProductsQueryValidator()
    {
        When(((p, _) => !string.IsNullOrEmpty(p.CategoryId)), () =>
        {
            RuleFor(item => item.CategoryId)
                .IsGuid();
        });
    }
}
