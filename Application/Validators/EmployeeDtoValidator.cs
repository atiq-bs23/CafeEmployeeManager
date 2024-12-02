using CafeEmployeeManager.Application.DTOs;
using FluentValidation;

namespace CafeEmployeeManager.Application.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(6, 100).WithMessage("Name must be between 6 and 100 characters.");

            RuleFor(e => e.EmailAddress)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Email address is not valid.");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^[89][0-9]{7}$").WithMessage("Phone number must start with 8 or 9 and have 8 digits.");

            RuleFor(e => e.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .Must(g => g == "Male" || g == "Female").WithMessage("Gender must be 'Male' or 'Female'.");
        }
    }
}
