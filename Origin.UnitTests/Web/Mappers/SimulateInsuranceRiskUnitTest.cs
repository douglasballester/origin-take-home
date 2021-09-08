using Origin.Application.Dtos.Enums;
using Origin.Application.Dtos.Insurace;
using Origin.Application.Dtos.Insurance;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Web.Mapper;
using Origin.Web.Requests;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Web.Mappers
{
    public class SimulateInsuranceRiskUnitTest
    {
        [Fact]
        public void Should_Map_Request_Correctly()
        {
            //Arrange
            var houseRequest = new HouseRequest { OwnershipStatus = "owned" };
            var vehicleRequest = new VehicleRequest { Year = 2000 };
            var simulateInsuranceRiskRequest = new SimulateInsuranceRiskRequest 
            {
                Age = 35,
                Dependents = 2,
                House = houseRequest,
                Income = 1000,
                MaritalStatus = "married",
                RiskQuestions = new List<byte> { 1, 1, 1},
                Vehicle = vehicleRequest
            };

            //Act
            var userDto = simulateInsuranceRiskRequest.MapRequest();

            //Assert
            Assert.Equal(simulateInsuranceRiskRequest.Age, userDto.Age);
            Assert.Equal(simulateInsuranceRiskRequest.Dependents, userDto.Dependents);
            Assert.Equal(OwnershipStatus.Owned, userDto.House.OwnershipStatus);
            Assert.Equal(simulateInsuranceRiskRequest.Income, userDto.Income);
            Assert.Equal(MaritalStatus.Married, userDto.MaritalStatus);
            Assert.Equal(simulateInsuranceRiskRequest.RiskQuestions, userDto.RiskQuestions);
            Assert.Equal(vehicleRequest.Year, userDto.Vehicle.Year);
        }

        [Fact]
        public void Should_Map_Response_Correctly()
        {
            //Arrange
            
            var autoInsurance = new InsuranceDto { Name = "Auto", Risk = "ineligible" };
            var homeInsurance = new InsuranceDto { Name = "Home", Risk = "economic" };
            var disabilityInsurance = new InsuranceDto { Name = "Disability", Risk = "regular" };
            var lifeInsurance = new InsuranceDto { Name = "Life", Risk = "responsible" };

            var insurance = new InsuranceRiskDto { User = null, Insurances = new List<InsuranceDto> { autoInsurance, homeInsurance, disabilityInsurance, lifeInsurance } };

            //Act
            var response = insurance.MapResponse();

            //Assert
            Assert.Equal(autoInsurance.Risk, response.Auto);
            Assert.Equal(homeInsurance.Risk, response.Home);
            Assert.Equal(disabilityInsurance.Risk, response.Disability);
            Assert.Equal(lifeInsurance.Risk, response.Life);
        }
    }
}
