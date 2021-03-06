using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class IncomeAboveTwoHundredDeductOneRule : IRule<Insurance, User>
    {
        private readonly int _twoHundredThousand = 200000;

        public void Validate(Insurance insurance, User user)
        {
            if (user.Income > _twoHundredThousand)
            {
                insurance.DeductScore(1);
            }
        }
    }
}
