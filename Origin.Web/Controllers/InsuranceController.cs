using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Origin.Application.Dtos.Insurance;
using Origin.Application.Interfaces;
using Origin.Web.Mapper;
using Origin.Web.Reponses;
using Origin.Web.Requests;

namespace Origin.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly ILogger<InsuranceController> _logger;
        private readonly IInsuranceRiskService _insuranceRiskService;

        public InsuranceController(ILogger<InsuranceController> logger, IInsuranceRiskService insuranceRiskService)
        {
            _logger = logger;
            _insuranceRiskService = insuranceRiskService;
        }

        [HttpPost]
        public SimulateInsuranceRiskResponse SimulateInsuranceRisk(SimulateInsuranceRiskRequest request)
        {
            var userDto = request.MapRequest();
            
            var simulationResult = _insuranceRiskService.Simulate(userDto);

            return simulationResult.MapResponse();
        }
    }
}
