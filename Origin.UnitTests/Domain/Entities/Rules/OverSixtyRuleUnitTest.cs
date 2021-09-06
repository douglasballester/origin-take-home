using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class OverSixtyRuleUnitTest
    {
        [Fact]
        public void Should_Set_Insurance_Ineligible_If_Age_Over_Sixty()
        {
            // Arrange
            var user = new User(61, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new OverSixtySetIneligibleRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.True(insurance.Ineligible);
        }

        [Fact]
        public void Should_Do_Nothing_If_Age_Under_Or_Equal_Sixty()
        {
            // Arrange
            var user = new User(60, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new OverSixtySetIneligibleRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.False(insurance.Ineligible);
        }
    }
}
