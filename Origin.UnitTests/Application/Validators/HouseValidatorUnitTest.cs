using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Validators;
using Xunit;
using ApplicationEnum = Origin.Application.Dtos.Enums;

namespace Origin.UnitTests.Application.Validators
{
    public class HouseValidatorUnitTest
    {
        [Fact]
        public void Should_Validate_House_Dto_And_Succeed()
        {
            //Arrange
            var houseDto = new HouseDto { OwnershipStatus = ApplicationEnum.OwnershipStatus.Owned };
            var houseValidator = new HouseValidator();

            //Act
            var validationResults = houseValidator.Validate(houseDto);

            //Assert
            Assert.True(validationResults.IsValid);
        }

        [Fact]
        public void Should_Validate_House_Dto_And_Fail()
        {
            //Arrange
            var houseDto = new HouseDto { OwnershipStatus = 0 };
            var houseValidator = new HouseValidator();

            //Act
            var validationResults = houseValidator.Validate(houseDto);

            //Assert
            Assert.False(validationResults.IsValid);
        }
    }
}
