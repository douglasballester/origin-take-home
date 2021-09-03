using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Rules;

namespace Origin.Domain.Entities.Insurances
{
    public class LifeInsurance : Insurance
    {
        public override string Name => "Life";

        public LifeInsurance(int score) : base(score)
        { }

        public override void RunValidations(User user)
        {
            RunRules.For(this, user)
                .Add(new OverSixtySetIneligibleRule())
                .Add(new UserAgeDeductScoreRule())
                .Add(new IncomeAboveTwoHundredDeductOneRule())
                .Add(new HasDependentsAddOneRule())
                .Add(new IsMarriedAddOneRule())
                .Run();
        }
    }
}
