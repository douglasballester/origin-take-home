using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Rules;

namespace Origin.Domain.Entities.Insurances
{
    public class HomeInsurance : Insurance
    {
        public override string Name => "Home";

        public HomeInsurance(int score) : base(score)
        { }

        public override void RunValidations(User user)
        {
            RunRules.For(this, user)
                .Add(new DoesntHaveHouseSetIneligibleRule())
                .Add(new UserAgeDeductScoreRule())
                .Add(new IncomeAboveTwoHundredDeductOneRule())
                .Add(new HouseMortgagedAddOneRule())
                .Run();
        }
    }
}
