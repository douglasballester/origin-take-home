using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Mappers;
using Origin.Domain.Entities.PersonalInfo;
using Xunit;

namespace Origin.UnitTests.Application.Mappers
{
    public class VehicleMapperUnitTest
    {
        [Fact]
        public void Should_Map_Vehicle_Dto_To_Domain_Correctly()
        {
            //Arrange
            var vehicleDto = new VehicleDto { Year = 2005 };

            //Act
            var vehicleDomain = vehicleDto.Map();

            //Assert
            Assert.Equal(vehicleDto.Year, vehicleDomain.Year);
        }

        [Fact]
        public void Should_Map_Vehicle_Domain_To_Dto_Correctly()
        {
            //Arrange
            var vehicle = new Vehicle(2005);

            //Act
            var vehicleDto = vehicle.MapDto();

            //Assert
            Assert.Equal(vehicle.Year, vehicleDto.Year);
        }
    }
}
