using FluentValidation;

namespace Server.Features.Licenses.Delete;

public class DeleteLicenseCommandValidator : AbstractValidator<DeleteLicenseCommand>
{
    public DeleteLicenseCommandValidator()
    {
        
    }
}
