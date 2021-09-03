using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;

namespace Origin.Domain.Rules
{
    public class HouseMortgagedAddOneRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.House?.OwnershipStatus == OwnershipStatus.Mortgaged)
            {
                insurance.AddScore(1);
            }
        }
    }
}
