using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using Origin.Domain.Rules;
using System;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Rules
{
    public class VehicleAgeRuleUnitTest
    {
        [Fact]
        public void Should_Add_One_Insurance_Score_If_Vehicle_Is_Newer_Than_Five_Years()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, new Vehicle(DateTime.Now.Year - 4));
            var insurance = new AutoInsurance(0);
            var rule = new VehicleWasProducedLastFiveYearsAddOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(1, insurance.Score);
        }

        [Fact]
        public void Should_Do_Nothing_If_Vehicle_Is_Older_Than_Five_Years()
        {
            // Arrange
            var user = new User(0, 0, 0, MaritalStatus.Married, new List<byte>(), null, new Vehicle(DateTime.Now.Year - 6));
            var insurance = new AutoInsurance(0);
            var rule = new VehicleWasProducedLastFiveYearsAddOneRule();

            //Act
            rule.Validate(insurance, user);

            //Assert
            Assert.Equal(0, insurance.Score);
        }
    }
}
