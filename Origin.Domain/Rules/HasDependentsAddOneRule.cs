using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class HasDependentsAddOneRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.Dependents is not 0)
            {
                insurance.DeductScore(1);
            }
        }
    }
}
