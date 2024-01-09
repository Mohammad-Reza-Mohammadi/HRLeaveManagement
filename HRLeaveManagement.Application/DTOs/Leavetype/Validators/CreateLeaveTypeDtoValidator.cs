using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.Leavetype.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            //RuleFor(p => p.Name)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} myst not exceed {ComparisonValue} characters.");

            //RuleFor(p => p.DefaultDays)
            //    .NotEmpty().WithMessage("{PropertyName} is required")
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
            //    .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}");
        }

    }
}
