using Common.Validator;
using FluentValidation;

namespace Server.Features.Files.FetchFileById;

public class FetchFileByIdQueryValidator: AbstractValidator<FetchFileByIdQuery>
{
    public FetchFileByIdQueryValidator()
    {
        RuleFor(p => p.FileId)
            .NotEmpty()
            .IsGuid();
    }
}
