using System.Data;
using Common.Validator;
using FluentValidation;

namespace Server.Features.Categories.Unlock;

public class UnlockCategoryCommandValidator :AbstractValidator<UnlockCategoryCommand>
{
    public UnlockCategoryCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
    }
}
