using Common.Validator;
using FluentValidation;

namespace Server.Features.Licenses.Create;

public class CreateLicenseCommandValidator : AbstractValidator<CreateLicenseCommand>
{
    public CreateLicenseCommandValidator()
    {
        RuleFor(a => a.DepartmentId)
            .NotEmpty();
        RuleFor(a => a.ProductId)
            .IsGuid();
        RuleFor(a => a.PriceInUSD)
            .NotEmpty();
        RuleFor(a => a.NumOfDevices)
            .NotEmpty();
        RuleFor(a => a.TimeType)
            .NotEmpty();
        RuleFor(a => a.PriceInLYD)
            .NotEmpty();
        RuleFor(a => a.StartDate)
            .NotEmpty();
        RuleFor(a => a.ExpireDate)
            .NotEmpty();
        RuleFor(a => a.ImpactLevel)
            .NotEmpty();

    }
}
