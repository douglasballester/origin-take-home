using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Validators;
using Xunit;

namespace Origin.UnitTests.Application.Validators
{
    public class VehicleValidatorUnitTest
    {
        [Fact]
        public void Should_Validate_Vehicle_Dto_And_Succeed()
        {
            //Arrange
            var vehicleDto = new VehicleDto { Year = 2018};
            var vehicleValidator = new VehicleValidator();

            //Act
            var validationResults = vehicleValidator.Validate(vehicleDto);

            //Assert
            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void Should_Validate_Vehicle_Dto_And_Fail()
        {
            //Arrange
            var vehicleDto = new VehicleDto { Year = 0 };
            var vehicleValidator = new VehicleValidator();

            //Act
            var validationResults = vehicleValidator.Validate(vehicleDto);

            //Assert
            Assert.False(validationResults.IsValid);
        }
    }
}
