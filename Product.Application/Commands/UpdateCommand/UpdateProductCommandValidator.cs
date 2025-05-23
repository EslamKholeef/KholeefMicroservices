using FluentValidation;

namespace Product.Application.Commands.UpdateCommand
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Title is required.");

            RuleFor(p => p.Price)
                .GreaterThan(100)
                .WithMessage("Price must be greater than 100.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .Must(desc => desc != null && desc.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length >= 5)
                .WithMessage("Description must contain at least 5 words.");
        }
    }
}
