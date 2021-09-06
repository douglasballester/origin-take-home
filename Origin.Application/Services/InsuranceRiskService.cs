using Origin.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Validators;
using Origin.Application.Dtos.Insurance;
using Origin.Application.Mappers;
using Origin.Domain.Entities;

namespace Origin.Application.Services
{
    public class InsuranceRiskService : IInsuranceRiskService
    {
        private readonly ILogger<InsuranceRiskService> _logger;

        public InsuranceRiskService(ILogger<InsuranceRiskService> logger)
        {
            _logger = logger;
        }

        public InsuranceRiskDto Simulate(UserDto userDto)
        {
            var validator = new UserValidator();
            var validationResult = validator.Validate(userDto);

            if (!validationResult.IsValid)
            {
                //Implement notification
                return null;
            }

            var user = userDto.Map();

            var insuranceRisk = new InsuranceRisk(user);
            insuranceRisk.RunInsuranceValidations();

            var insuranceRiskDto = insuranceRisk.MapDto();

            return insuranceRiskDto;
        }
    }
}
