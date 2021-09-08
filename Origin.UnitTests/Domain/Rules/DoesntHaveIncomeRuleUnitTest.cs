using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class DoesntHaveIncomeRuleUnitTest
    {
        [Fact]
        public void Should_Set_Insurance_Ineligible_If_Income_Is_Zero()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new DoesntHaveIncomeSetIneligibleRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.True(insurance.Ineligible);
        }

        [Fact]
        public void Should_Do_Nothing_If_Has_Income()
        {
            // Arrange
            var user = new User(0, 0, 300, MaritalStatus.Married, new List<byte>(), new House(OwnershipStatus.Owned), null);
            var insurance = new HomeInsurance(0);
            var rule = new DoesntHaveIncomeSetIneligibleRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.False(insurance.Ineligible);
        }
    }
}
