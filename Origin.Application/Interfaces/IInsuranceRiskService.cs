using Origin.Application.Dtos.Insurance;
using Origin.Application.Dtos.PersonalInfo;

namespace Origin.Application.Interfaces
{
    public interface IInsuranceRiskService
    {
        InsuranceRiskDto Simulate(UserDto simulateInsuranceRisk);
    }
}
