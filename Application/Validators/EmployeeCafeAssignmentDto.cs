using CafeEmployeeManager.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeManager.Application.Validators
{
    public class EmployeeCafeAssignmentDtoValidator : AbstractValidator<EmployeeCafeAssignmentDto>
    {
        public EmployeeCafeAssignmentDtoValidator()
        {
            RuleFor(a => a.EmployeeId).NotEmpty().WithMessage("Employee ID is required.");
            RuleFor(a => a.CafeId).NotEmpty().WithMessage("Cafe ID is required.");
        }
    }
}
