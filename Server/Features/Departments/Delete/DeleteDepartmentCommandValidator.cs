using FluentValidation;

namespace Server.Features.Departments.Delete;

public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentCommandValidator()
    {
        
    }
}
