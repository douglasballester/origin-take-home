using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Rules;

namespace Origin.Domain.Entities.Insurances
{
    public class DisabilityInsurance : Insurance
    {
        public override string Name => "Disability";

        public DisabilityInsurance(int score) : base(score)
        { }

        public override void RunValidations(User user)
        {
            RunRules.For(this, user)
                .Add(new DoesntHaveIncomeSetIneligibleRule())
                .Add(new OverSixtySetIneligibleRule())
                .Add(new UserAgeDeductScoreRule())
                .Add(new IncomeAboveTwoHundredDeductOneRule())
                .Add(new HouseMortgagedAddOneRule())
                .Add(new HasDependentsAddOneRule())
                .Add(new IsMarriedDeductOneRule())
                .Run();
        }
    }
}
