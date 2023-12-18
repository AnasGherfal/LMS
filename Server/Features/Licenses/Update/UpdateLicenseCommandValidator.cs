using FluentValidation;

namespace Server.Features.Licenses.Update;

public class UpdateLicenseCommandValidator:AbstractValidator<UpdateLicenseCommand>
{
    public UpdateLicenseCommandValidator()
    {
        
    }
}
