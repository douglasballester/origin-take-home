using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Rules;

namespace Origin.Domain.Entities.Insurances
{
    public class AutoInsurance : Insurance
    {
        public override string Name => "Auto";

        public AutoInsurance(int score) : base (score)
        { }

        public override void RunValidations(User user)
        {
            RunRules.For(this, user)
                .Add(new DoesntHaveVehicleSetIneligibleRule())
                .Add(new UserAgeDeductScoreRule())
                .Add(new IncomeAboveTwoHundredDeductOneRule())
                .Add(new VehicleWasProducedLastFiveYearsAddOneRule())
                .Run();
        }
    }
}
