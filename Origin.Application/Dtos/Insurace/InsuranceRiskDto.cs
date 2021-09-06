using Origin.Application.Dtos.Insurace;
using Origin.Application.Dtos.PersonalInfo;
using System.Collections.Generic;

namespace Origin.Application.Dtos.Insurance
{
    public class InsuranceRiskDto
    {
        public UserDto User { get; set; }
        public List<InsuranceDto> Insurances { get; set; }
    }
}
