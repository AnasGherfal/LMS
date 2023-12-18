using Common.Validator;
using FluentValidation;

namespace Server.Features.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(a => a.CategoryId)
            .IsGuid();
        RuleFor(a => a.Name)
            .NotEmpty();
        RuleFor(a => a.Description)
            .NotEmpty();
        RuleFor(a => a.Provider)
            .NotEmpty();
        RuleFor(item => item.Photo)
            .NotNull()
            .SetValidator(new ImageFileValidator("CATEGORY_IMAGE"));
    }
}
