using Common.Validator;
using FluentValidation;

namespace Server.Features.Licenses.Delete;

public class DeleteLicenseCommandValidator : AbstractValidator<DeleteLicenseCommand>
{
    public DeleteLicenseCommandValidator()
    {
        RuleFor(c => c.Id)
          .NotEmpty()
          .IsGuid();
    }
}
