using Common.Validator;
using FluentValidation;

namespace Server.Features.Products.Lock;

public class LockProductCommandValidator: AbstractValidator<LockProductCommand>
{
    public LockProductCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
    }
}
