using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class OverSixtySetIneligibleRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.Age > 60)
            {
                insurance.SetIneligible();
            }
        }
    }
}
