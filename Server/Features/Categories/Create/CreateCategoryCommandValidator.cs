using Common.Validator;
using FluentValidation;

namespace Server.Features.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty();
        RuleFor(a => a.Description)
            .NotEmpty();
        RuleFor(item => item.Photo)
            .NotNull()
            .SetValidator(new ImageFileValidator("CATEGORY_IMAGE"));
    }
}
