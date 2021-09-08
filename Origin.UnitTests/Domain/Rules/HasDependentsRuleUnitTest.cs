using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class HasDependentsRuleUnitTest
    {
        [Fact]
        public void Should_Add_One_Insurance_Score_If_Has_Dependents()
        {
            // Arrange
            var user = new User(0, 1, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new AutoInsurance(0);
            var rule = new HasDependentsAddOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(1, insurance.Score);
        }

        [Fact]
        public void Should_Do_Nothing_If_Has_Zero_Dependents()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, null);
            var insurance = new AutoInsurance(0);
            var rule = new HasDependentsAddOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(0, insurance.Score);
        }
    }
}
