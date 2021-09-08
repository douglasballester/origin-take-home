using Origin.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Validators;
using Origin.Application.Dtos.Insurance;
using Origin.Application.Mappers;
using Origin.Domain.Entities;
using Origin.Common.Notifications;
using System.Linq;

namespace Origin.Application.Services
{
    public class InsuranceRiskService : IInsuranceRiskService
    {
        private readonly ILogger<InsuranceRiskService> _logger;
        private readonly NotificationContext _notificationContext;

        public InsuranceRiskService(ILogger<InsuranceRiskService> logger, NotificationContext notificationContext)
        {
            _logger = logger;
            _notificationContext = notificationContext;
        }

        public InsuranceRiskDto Simulate(UserDto userDto)
        {
            var validator = new UserValidator();
            var validationResult = validator.Validate(userDto);

            if (!validationResult.IsValid)
            {
                _notificationContext.AddNotifications(validationResult.Errors.Select(x => x.ErrorMessage).ToList());
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
