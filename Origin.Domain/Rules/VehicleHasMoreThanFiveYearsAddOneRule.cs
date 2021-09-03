using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;
using System;

namespace Origin.Domain.Rules
{
    public class VehicleHasMoreThanFiveYearsAddOneRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (DateTime.Now.Year - user.Vehicle?.Year > 5 )
            {
                insurance.AddScore(1);
            }
        }
    }
}
