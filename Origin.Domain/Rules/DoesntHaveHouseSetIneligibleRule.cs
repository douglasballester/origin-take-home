using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class DoesntHaveHouseSetIneligibleRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.House is null)
            {
                insurance.SetIneligible();
            }
        }
    }
}
