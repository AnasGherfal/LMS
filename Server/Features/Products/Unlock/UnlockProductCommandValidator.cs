using Common.Validator;
using FluentValidation;

namespace Server.Features.Products.Unlock;

public class UnlockProductCommandValidator :AbstractValidator<UnlockProductCommand>
{
    public UnlockProductCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
    }
}
