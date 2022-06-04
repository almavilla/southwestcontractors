﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Features.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandValidator : AbstractValidator<CreateContractorCommand>
    {
        public CreateContractorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is requiered")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("{PropertyName} is requiered")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        }
    }
}
