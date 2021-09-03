using Origin.Domain.Bases;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Rules
{
    public class UserAgeDeductScoreRule : IRule<Insurance, User>
    {
        public void Validate(Insurance insurance, User user)
        {
            if (user.Age < 30)
            {
                insurance.DeductScore(2);
            } 
            else if (user.Age >= 30 && user.Age <= 40)
            {
                insurance.DeductScore(1);
            }
        }
    }
}
