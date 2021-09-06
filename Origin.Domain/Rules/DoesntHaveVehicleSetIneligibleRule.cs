using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class DoesntHaveVehicleSetIneligibleRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.Vehicle is null)
            {
                insurance.SetIneligible();
            }
        }
    }
}
