using Origin.Domain.Bases;
using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Origin.Domain.Entities
{
    public class InsuranceRisk
    {
        public User User { get; private set; }
        public List<Insurance> Insurances { get; }

        public InsuranceRisk(User user)
        {
            User = user;
            Insurances = new List<Insurance>();

            var baseScore = user.RiskQuestions.Select(Convert.ToInt32).Sum();
            BuildInsurances(baseScore);
        }

        public void RunInsuranceValidations()
        {
            Insurances.ForEach(insurance => insurance.RunValidations(User));
        }

        private void BuildInsurances(int baseScore)
        {
            Insurances.Add(new AutoInsurance(baseScore));
            Insurances.Add(new HomeInsurance(baseScore));
            Insurances.Add(new LifeInsurance(baseScore));
            Insurances.Add(new DisabilityInsurance(baseScore));
        }
    }
}
