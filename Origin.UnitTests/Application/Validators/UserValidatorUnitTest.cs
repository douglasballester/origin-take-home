using Origin.Application.Dtos.Enums;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Validators;
using System.Collections.Generic;
using Xunit;

namespace Origin.UnitTests.Application.Validators
{
    public class UserValidatorUnitTest
    {
        [Theory, MemberData(nameof(DataToSucceed))]
        public void Should_Validate_User_Dto_And_Succeed(UserDto userDto)
        {
            //Arrange            
            var userValidator = new UserValidator();

            //Act
            var validationResults = userValidator.Validate(userDto);

            //Assert
            Assert.True(validationResults.IsValid);
        }

        [Theory, MemberData(nameof(DataToFail))]
        public void Should_Validate_User_Dto_And_Fail(UserDto userDto)
        {
            //Arrange
            var userValidator = new UserValidator();

            //Act
            var validationResults = userValidator.Validate(userDto);

            //Assert
            Assert.False(validationResults.IsValid);
        }

        public static IEnumerable<object[]> DataToSucceed =>
            new List<object[]>
            {
                new object[]
                {
                    new UserDto
                    {
                        Age = 35,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 35,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 35,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned }
                    },
                },
            };

        public static IEnumerable<object[]> DataToFail =>
            new List<object[]>
            {
                new object[]
                {
                    new UserDto
                    {
                        Age = -1,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 16,
                        Dependents = 1,
                        Income = -20,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 30,
                        Dependents = -2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 30,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = 0,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 30,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 2, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 30,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = 0 },
                        Vehicle = new VehicleDto { Year = 2018 }
                    },
                },
                new object[]
                {
                    new UserDto
                    {
                        Age = 30,
                        Dependents = 2,
                        Income = 0,
                        MaritalStatus = MaritalStatus.Married,
                        RiskQuestions = new List<byte> { 0, 1, 0 },
                        House = new HouseDto { OwnershipStatus = OwnershipStatus.Owned },
                        Vehicle = new VehicleDto { Year = 0 }
                    },
                },
            };
    }
}
