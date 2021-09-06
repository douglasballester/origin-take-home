using Origin.Application.Mappers;
using Origin.Domain.Entities.Insurances;
using Xunit;

namespace Origin.UnitTests.Application.Mappers
{
    public class InsuranceMapperUnitTest
    {
        [Fact]
        public void Should_Map_Insurance_Domain_To_Dto_Correctly()
        {
            //Arrange
            var insurance = new AutoInsurance(0);

            //Act
            var insuranceDto = insurance.MapDto();

            //Assert
            Assert.Equal(insurance.Name, insuranceDto.Name);
            Assert.Equal(insurance.Risk, insuranceDto.Risk);
            Assert.Equal(insurance.Score, insuranceDto.Score);
            Assert.Equal(insurance.Ineligible, insuranceDto.Ineligible);
        }
    }
}
