using FluentValidation;
using Origin.Application.Dtos.PersonalInfo;

namespace Origin.Application.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Field Age needs to be greater than 0");
            RuleFor(x => x.Dependents).GreaterThanOrEqualTo(0).WithMessage("Field Dependents needs to be greater or equal 0"); ;
            RuleFor(x => x.Income).GreaterThanOrEqualTo(0).WithMessage("Field Income needs to be greater or equal than 0"); ;
            RuleFor(x => x.MaritalStatus).IsInEnum().WithMessage("Field Marital Status needs to be valid");
            RuleFor(x => x.RiskQuestions).Must(x => x.Count == 3).WithMessage("The number of questions needs to be equal 3");
            RuleFor(x => x.RiskQuestions).ForEach(boolRule => boolRule.Must(BeAValidValue)).WithMessage("The number of questions needs to be equal 3");
            RuleFor(x => x.House).SetValidator(new HouseValidator()).When(x => x.House is not null);
            RuleFor(x => x.Vehicle).SetValidator(new VehicleValidator()).When(x => x.Vehicle is not null);            
        }
        private static bool BeAValidValue(byte arg)
        {
            return arg.Equals(0) || arg.Equals(1);
        }
    }
}
