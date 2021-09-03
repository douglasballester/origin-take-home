using Origin.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Origin.Application.Services
{
    public class InsuranceRiskService : IInsuranceRiskService
    {
        private readonly ILogger<InsuranceRiskService> _logger;

        public InsuranceRiskService(ILogger<InsuranceRiskService> logger)
        {
            _logger = logger;
        }


    }
}
