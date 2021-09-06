using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class UserAgeRuleUnitTest
    {
        [Fact]
        public void Should_Deduct_Two_Insurance_Score_If_Age_Under_Thirty()
        {
            // Arrange
            var user = new User(29, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new UserAgeDeductScoreRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(-2, insurance.Score);
        }

        [Fact]
        public void Should_Deduct_One_Insurance_Score_If_Age_Between_Thirty_And_Forty()
        {
            // Arrange
            var user = new User(35, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new UserAgeDeductScoreRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(-1, insurance.Score);
        }

        [Fact]
        public void Should_Do_Nothing_If_Age_Over_Forty()
        {
            // Arrange
            var user = new User(41, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new UserAgeDeductScoreRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(0, insurance.Score);
        }
    }
}
