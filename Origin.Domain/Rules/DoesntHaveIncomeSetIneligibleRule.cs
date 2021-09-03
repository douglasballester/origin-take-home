using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class DoesntHaveIncomeSetIneligibleRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.Income is 0)
            {
                insurance.SetIneligible();
            }
        }
    }
}
