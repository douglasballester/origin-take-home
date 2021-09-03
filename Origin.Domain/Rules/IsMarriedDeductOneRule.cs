using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;

namespace Origin.Domain.Rules
{
    public class IsMarriedDeductOneRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.MaritalStatus == MaritalStatus.Married)
            {
                insurance.DeductScore(1);
            }
        }
    }
}
