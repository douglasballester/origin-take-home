using FluentValidation;
using Origin.Application.Dtos.PersonalInfo;
using System;

namespace Origin.Application.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleDto>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.Year).GreaterThan(1900).LessThanOrEqualTo(DateTime.Now.Year + 1).WithMessage("Year of manufactor is not valid");
        }
    }
}
