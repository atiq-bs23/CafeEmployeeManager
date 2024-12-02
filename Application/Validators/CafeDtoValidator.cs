using CafeEmployeeManager.Application.DTOs;
using FluentValidation;

namespace CafeEmployeeManager.Application.Validators
{
    public class CafeDtoValidator : AbstractValidator<CafeDto>
    {
        public CafeDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(6, 100).WithMessage("Name must be between 6 and 100 characters.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(256).WithMessage("Description must be less than 256 characters.");

            RuleFor(c => c.Location)
                .NotEmpty().WithMessage("Location is required.");

            RuleFor(c => c.Logo)
                .MaximumLength(2 * 1024 * 1024)
                .When(c => !string.IsNullOrEmpty(c.Logo))
                .WithMessage("Logo must not exceed 2MB.");
        }
    }
}
