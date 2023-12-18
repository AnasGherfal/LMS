using Common.Validator;
using FluentValidation;

namespace Server.Features.Categories.Lock;

public class LockCategoryCommandValidator:AbstractValidator<LockCategoryCommand>
{
    public LockCategoryCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
    }
}
