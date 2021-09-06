using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Mappers;
using Origin.Domain.Entities.PersonalInfo;
using Xunit;
using ApplicationEnum = Origin.Application.Dtos.Enums;
using DomainEnum = Origin.Domain.Enums;

namespace Origin.UnitTests.Application.Mappers
{
    public class HouseMapperUnitTest
    {
        [Fact]
        public void Should_Map_House_Dto_To_Domain_Correctly()
        {
            //Arrange
            var houseDto = new HouseDto { OwnershipStatus = ApplicationEnum.OwnershipStatus.Owned };

            //Act
            var houseDomain = houseDto.Map();

            //Assert
            Assert.Equal((DomainEnum.OwnershipStatus)houseDto.OwnershipStatus, houseDomain.OwnershipStatus);
        }

        [Fact]
        public void Should_Map_Vehicle_Domain_To_Dto_Correctly()
        {
            //Arrange
            var house = new House(DomainEnum.OwnershipStatus.Owned);

            //Act
            var houseDto = house.MapDto();

            //Assert
            Assert.Equal((ApplicationEnum.OwnershipStatus)house.OwnershipStatus, houseDto.OwnershipStatus);
        }
    }
}
