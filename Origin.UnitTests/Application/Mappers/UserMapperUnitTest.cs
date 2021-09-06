using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Mappers;
using Origin.Domain.Entities.PersonalInfo;
using System.Collections.Generic;
using Xunit;
using ApplicationEnum = Origin.Application.Dtos.Enums;
using DomainEnum = Origin.Domain.Enums;

namespace Origin.UnitTests.Application.Mappers
{
    public class UserMapperUnitTest
    {
        [Fact]
        public void Should_Map_User_Dto_To_Domain_Correctly()
        {
            //Arrange
            var houseDto = new HouseDto { OwnershipStatus = ApplicationEnum.OwnershipStatus.Owned };
            var vehicleDto = new VehicleDto { Year = 2000 };
            var userDto = new UserDto
            {
                Age = 35,
                Dependents = 2,
                Income = 50000,
                MaritalStatus = ApplicationEnum.MaritalStatus.Single,
                RiskQuestions = new List<byte> {1,1,1},
                Vehicle = vehicleDto,
                House = houseDto
            };

            //Act
            var userDomain = userDto.Map();

            //Assert
            Assert.Equal(userDto.Age, userDomain.Age);
            Assert.Equal(userDto.Dependents, userDomain.Dependents);
            Assert.Equal(userDto.Income, userDomain.Income);
            Assert.Equal(userDto.RiskQuestions, userDomain.RiskQuestions);
            Assert.Equal((DomainEnum.MaritalStatus)userDto.MaritalStatus, userDomain.MaritalStatus);
            Assert.Equal((DomainEnum.OwnershipStatus)userDto.House.OwnershipStatus, userDomain.House.OwnershipStatus);
            Assert.Equal(userDto.Vehicle.Year, userDomain.Vehicle.Year);
        }

        [Fact]
        public void Should_Map_User_Domain_To_Dto_Correctly()
        {
            //Arrange
            var vehicle = new Vehicle(2000);
            var house = new House(DomainEnum.OwnershipStatus.Owned);
            var user = new User(35, 2, 50000, DomainEnum.MaritalStatus.Single, new List<byte> { 1, 1, 1 }, house, vehicle);

            //Act
            var userDto = user.MapDto();

            //Assert
            Assert.Equal(user.Age, userDto.Age);
            Assert.Equal(user.Dependents, userDto.Dependents);
            Assert.Equal(user.Income, userDto.Income);
            Assert.Equal(user.RiskQuestions, userDto.RiskQuestions);
            Assert.Equal((ApplicationEnum.MaritalStatus)user.MaritalStatus, userDto.MaritalStatus);
            Assert.Equal((ApplicationEnum.OwnershipStatus)user.House.OwnershipStatus, userDto.House.OwnershipStatus);
            Assert.Equal(user.Vehicle.Year, userDto.Vehicle.Year);
        }
    }
}
