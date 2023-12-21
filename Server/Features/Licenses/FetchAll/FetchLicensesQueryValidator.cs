using Common.Validator;
using FluentValidation;

namespace Server.Features.Licenses.FetchAll;

public class FetchLicensesQueryValidator : AbstractValidator<FetchLicensesQuery>
{
    public FetchLicensesQueryValidator()
    {
        
        When(((p, _) => !string.IsNullOrEmpty(p.ProductId)), () =>
        {
            RuleFor(item => item.ProductId)
                .IsGuid();
        });
    }
}
