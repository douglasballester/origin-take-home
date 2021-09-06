using Microsoft.Extensions.Logging;
using Moq;
using Origin.Application.Dtos.Enums;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Origin.UnitTests.Application.Service
{
    public class InsuranceRiskServiceUnitTest
    {
        [Theory, MemberData(nameof(Data))]
        public void Should_Simulate_Insurance_Risk_Correctly(UserDto userDto, string autoResult, string disabilityResult, string homeResult, string lifeResult)
        {
            //Arrange
            var mock = new Mock<ILogger<InsuranceRiskService>>();
            var insuranceService = new InsuranceRiskService(mock.Object);

            //Act
            var insuranceRiskDto = insuranceService.Simulate(userDto);

            //Assert
            Assert.Equal(autoResult, insuranceRiskDto.Insurances.First(x => x.Name == "Auto").Risk);
            Assert.Equal(disabilityResult, insuranceRiskDto.Insurances.First(x => x.Name == "Disability").Risk);
            Assert.Equal(homeResult, insuranceRiskDto.Insurances.First(x => x.Name == "Home").Risk);
            Assert.Equal(lifeResult, insuranceRiskDto.Insurances.First(x => x.Name == "Life").Risk);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] 
                { 
                    new UserDto
                    {
                        Age = 35,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                    "regular",
                    "ineligible",
                    "economic",
                    "regular"
                },
            };
    }
}
