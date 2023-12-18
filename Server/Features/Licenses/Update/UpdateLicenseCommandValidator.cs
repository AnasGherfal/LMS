using Common.Validator;
using FluentValidation;

namespace Server.Features.Licenses.Update;

public class UpdateLicenseCommandValidator:AbstractValidator<UpdateLicenseCommand>
{
    public UpdateLicenseCommandValidator()
    {
        RuleFor(c => c.Id)
          .NotEmpty()
          .IsGuid();
        When(((p, _) => p.Contact != null), () =>
        {
            RuleFor(a => a.Contact)
                .NotEmpty();
        });
        When(((p, _) => p.SerialKey != null), () =>
        {
            RuleFor(a => a.SerialKey)
                .NotEmpty();
        });
    }
}
