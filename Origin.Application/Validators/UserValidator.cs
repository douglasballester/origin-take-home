using FluentValidation;
using Origin.Application.Dtos.PersonalInfo;

namespace Origin.Application.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Age).NotNull().GreaterThan(0).WithMessage("Field 'age' needs to be greater than 0");
            RuleFor(x => x.Dependents).NotNull().GreaterThanOrEqualTo(0).WithMessage("Field 'dependents' needs to be greater or equal to 0"); ;
            RuleFor(x => x.Income).NotNull().GreaterThanOrEqualTo(0).WithMessage("Field 'income' needs to be greater or equal to 0"); ;
            RuleFor(x => x.MaritalStatus).IsInEnum().WithMessage("Field 'marital_status' needs to be valid");
            RuleFor(x => x.RiskQuestions).Must(x => x.Count == 3).WithMessage("The number of questions needs to be equal 3");
            RuleFor(x => x.RiskQuestions).ForEach(boolRule => boolRule.Must(BeAValidValue)).WithMessage("The values inside risk_questions needs to be 0 or 1");
            RuleFor(x => x.House).SetValidator(new HouseValidator()).When(x => x.House is not null);
            RuleFor(x => x.Vehicle).SetValidator(new VehicleValidator()).When(x => x.Vehicle is not null);            
        }
        private static bool BeAValidValue(byte arg)
        {
            return arg.Equals(0) || arg.Equals(1);
        }
    }
}
