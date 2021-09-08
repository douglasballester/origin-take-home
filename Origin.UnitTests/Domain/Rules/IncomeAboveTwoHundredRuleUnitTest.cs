using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class IncomeAboveTwoHundredRuleUnitTest
    {
        [Fact]
        public void Should_Deduct_One_Insurance_Score_If_Income_Above_Two_Hundred_Thousand()
        {
            // Arrange
            var user = new User(0, 0, 200000.01, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new HomeInsurance(0);
            var rule = new IncomeAboveTwoHundredDeductOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(-1, insurance.Score);
        }

        [Fact]
        public void Should_Do_Nothing_If_Income_Under_Two_Hundred_Thousand()
        {
            // Arrange
            var user = new User(0, 0, 199999, MaritalStatus.Married, new List<byte>(), new House(OwnershipStatus.Owned), null);
            var insurance = new HomeInsurance(0);
            var rule = new IncomeAboveTwoHundredDeductOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(0, insurance.Score);
        }
    }
}
