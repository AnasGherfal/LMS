using Common.Validator;
using FluentValidation;

namespace Server.Features.Categories.FetchById;

public class FetchCategoryQueryValidator : AbstractValidator<FetchCategoryQuery>
{
    public FetchCategoryQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
    }
}
