using Origin.Domain.Entities.PersonalInfo;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.PersonalInfo
{
    public class VehicleUnitTest
    {

        [Fact]
        public void Should_Create_Vehicle_With_Correct_Year()
        {
            // Arrange
            var year = 2005;
            var vehicle = new Vehicle(year);

            //Act and Assert
            Assert.Equal(vehicle.Year, year);
        }
    }
}
