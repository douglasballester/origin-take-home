using FluentValidation;
using Origin.Application.Dtos.PersonalInfo;

namespace Origin.Application.Validators
{
    public class HouseValidator : AbstractValidator<HouseDto>
    {
        public HouseValidator()
        {
            RuleFor(x => x.OwnershipStatus).IsInEnum().WithMessage("Ownership status is not valid");
        }
    }
}
