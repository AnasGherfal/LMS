using Common.Validator;
using FluentValidation;

namespace Server.Features.Licenses.FetchById;

public class FetchLicenseQueryValidator : AbstractValidator<FetchLicenseQuery>
{
    public FetchLicenseQueryValidator()
    {
        RuleFor(c => c.Id)
              .NotEmpty()
              .IsGuid();
    }
}
