using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class IsMarriedAddRuleUnitTest
    {
        [Fact]
        public void Should_Add_One_Insurance_Score_If_Is_Married()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new IsMarriedAddOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(1, insurance.Score);
        }

        [Fact]
        public void Should_Do_Nothing_If_Is_Single()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Single, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new IsMarriedAddOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(0, insurance.Score);
        }
    }
}
