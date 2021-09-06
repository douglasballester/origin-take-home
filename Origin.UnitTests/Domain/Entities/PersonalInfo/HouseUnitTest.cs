using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.PersonalInfo
{
    public class HouseUnitTest
    {
        [Fact]
        public void Should_Create_House_With_Owned_Status()
        {
            // Arrange
            var status = OwnershipStatus.Owned;
            var house = new House(status);

            //Act and Assert
            Assert.Equal(house.OwnershipStatus, status);
        }
    }
}
