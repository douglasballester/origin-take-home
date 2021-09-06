using Origin.Application.Dtos.Insurace;
using Origin.Domain.Bases;

namespace Origin.Application.Mappers
{
    public static class InsuranceMapper
    {
        public static InsuranceDto MapDto(this Insurance insurance) =>
            new InsuranceDto
            {
                Name = insurance.Name,
                Ineligible = insurance.Ineligible,
                Score = insurance.Score,
                Risk = insurance.Risk
            };
    }
}
