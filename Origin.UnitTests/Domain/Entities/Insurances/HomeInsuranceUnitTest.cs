using Origin.Domain.Entities.Insurances;
using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.Insurances
{
    public class HomeInsuranceUnitTest
    {
        [Theory, MemberData(nameof(Data))]
        public void Should_Run_Home_Insurance_Validations_And_Get_Expected_Values(int age,
                                                           int dependents,
                                                           double income,
                                                           MaritalStatus maritalStatus,
                                                           List<byte> riskQuestions,
                                                           House house,
                                                           Vehicle vehicle,
                                                           int expectedScore,
                                                           bool expectedIneligible)
        {
            // Arrange
            var user = new User(age,
                                dependents,
                                income,
                                maritalStatus,
                                riskQuestions,
                                house,
                                vehicle);
            var insurance = new HomeInsurance(0);

            //Act
            insurance.RunValidations(user);

            //Assert
            Assert.Equal(expectedScore, insurance.Score);
            Assert.Equal(expectedIneligible, insurance.Ineligible);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 35, 2, 0, MaritalStatus.Married, new List<byte> { 0, 0, 0 }, null, null, -1, true},
                new object[] { 61, 0, 350000, MaritalStatus.Married, new List<byte> { 0, 0, 0 }, new House(OwnershipStatus.Owned), null,-1, false},
                new object[] { 59, 0, 350000, MaritalStatus.Married, new List<byte> { 0, 0, 0 }, new House(OwnershipStatus.Owned), null,-1, false},
                new object[] { 29, 3, 50000, MaritalStatus.Single, new List<byte> { 0, 0, 0 }, new House(OwnershipStatus.Owned), null, -2, false },
                new object[] { 41, 3, 50000, MaritalStatus.Single, new List<byte> { 0, 0, 0}, new House(OwnershipStatus.Mortgaged), null, 1, false }
            };
    }
}
