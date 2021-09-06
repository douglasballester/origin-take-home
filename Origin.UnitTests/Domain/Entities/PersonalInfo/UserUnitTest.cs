using Origin.Domain.Entities.PersonalInfo;
using Origin.Domain.Enums;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Domain.Entities.PersonalInfo
{
    public class UserUnitTest
    {
        [Theory, MemberData(nameof(Data))]
        public void Should_Create_User_With_Correct_Values(int age, int dependents, double income, MaritalStatus maritalStatus, List<byte> riskQuestions, House house, Vehicle vehicle)
        {
            // Arrange
            var user = new User(age,
                                dependents,
                                income,
                                maritalStatus,
                                riskQuestions,
                                house,
                                vehicle);

            //Act and Assert
            Assert.Equal(user.Age, age);
            Assert.Equal(user.Dependents, dependents);
            Assert.Equal(user.Income, income);
            Assert.Equal(user.MaritalStatus, maritalStatus);
            Assert.Equal(user.RiskQuestions, riskQuestions);
            Assert.Equal(user.House.OwnershipStatus, house.OwnershipStatus);
            Assert.Equal(user.Vehicle.Year, vehicle.Year);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 35, 2, 0, MaritalStatus.Married, new List<byte> { 0, 1, 0 }, new House(OwnershipStatus.Mortgaged), new Vehicle(2005)},
                new object[] { 61, 0, 350000, MaritalStatus.Married, new List<byte> { 1, 1, 0 }, new House(OwnershipStatus.Owned), new Vehicle(2020)},
                new object[] { 29, 3, 0, MaritalStatus.Single, new List<byte> { 1, 1, 1 }, new House(OwnershipStatus.Owned), new Vehicle(2005) }
            };
    }
}
