using Origin.Application.Dtos.Insurance;
using Origin.Domain.Entities;
using System.Linq;

namespace Origin.Application.Mappers
{
    public static class InsuranceRiskMapper
    {
        public static InsuranceRiskDto MapDto(this InsuranceRisk insuranceRisk) =>
            new InsuranceRiskDto
            {
                User = insuranceRisk.User.MapDto(),
                Insurances = insuranceRisk.Insurances.Select(insurance => insurance.MapDto()).ToList()
            };
    }
}
