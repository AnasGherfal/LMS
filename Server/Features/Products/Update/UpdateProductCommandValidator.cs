using Common.Validator;
using FluentValidation;

namespace Server.Features.Products.Update;

public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
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
        When(((p, _) => p.Provider != null), () =>
        {
            RuleFor(a => a.Provider)
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
