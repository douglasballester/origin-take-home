using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class DoesntHaveVehicleRuleUnitTest
    {
        [Fact]
        public void Should_Set_Insurance_Ineligible_If_Vehicle_Is_Null()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new AutoInsurance(0);
            var rule = new DoesntHaveVehicleSetIneligibleRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.True(insurance.Ineligible);
        }

        [Fact]
        public void Should_Do_Nothing_If_Vehicle_Is_Valid()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, new Vehicle(2005));
            var insurance = new AutoInsurance(0);
            var rule = new DoesntHaveVehicleSetIneligibleRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.False(insurance.Ineligible);
        }
    }
}
