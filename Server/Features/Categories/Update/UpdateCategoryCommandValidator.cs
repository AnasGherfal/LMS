using Common.Validator;
using FluentValidation;

namespace Server.Features.Categories.Update;

public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .IsGuid();
        When(((p, _) => p.Name != null), () =>
        {
            RuleFor(a => a.Name)
                .NotEmpty();
        });
        When(((p, _) => p.Description != null), () =>
        {
            RuleFor(a => a.Description)
                .NotEmpty();
        });
        When(((p, _) => p.Photo != null), () =>
        {
            RuleFor(item => item.Photo)
                .NotNull()
                .SetValidator(new ImageFileValidator("CATEGORY_IMAGE"));
        });
    }
}
