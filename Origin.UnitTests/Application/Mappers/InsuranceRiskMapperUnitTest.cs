using Origin.Application.Dtos.PersonalInfo;
using Origin.Application.Mappers;
using Origin.Domain.Entities;
using Origin.Domain.Entities.PersonalInfo;
using System.Collections.Generic;
using Xunit;
using ApplicationEnum = Origin.Application.Dtos.Enums;
using DomainEnum = Origin.Domain.Enums;

namespace Origin.UnitTests.Application.Mappers
{
    public class InsuranceRiskMapperUnitTest
    {
        [Fact]
        public void Should_Map_InsuranceRisk_Domain_To_Dto_Correctly()
        {
            //Arrange
            var vehicle = new Vehicle(2000);
            var house = new House(DomainEnum.OwnershipStatus.Owned);
            var user = new User(35, 2, 50000, DomainEnum.MaritalStatus.Single, new List<byte> { 1, 1, 1 }, house, vehicle);
            var insurance = new InsuranceRisk(user);
            
            //Act
            var insuranceRiskDto = insurance.MapDto();

            //Assert
            Assert.Equal(insurance.Insurances.Count, insuranceRiskDto.Insurances.Count);
            Assert.Equal(user.Age, insuranceRiskDto.User.Age);
            Assert.Equal(user.Dependents, insuranceRiskDto.User.Dependents);
            Assert.Equal(user.Income, insuranceRiskDto.User.Income);
            Assert.Equal(user.RiskQuestions, insuranceRiskDto.User.RiskQuestions);
            Assert.Equal((ApplicationEnum.MaritalStatus)user.MaritalStatus, insuranceRiskDto.User.MaritalStatus);
            Assert.Equal((ApplicationEnum.OwnershipStatus)user.House.OwnershipStatus, insuranceRiskDto.User.House.OwnershipStatus);
            Assert.Equal(user.Vehicle.Year, insuranceRiskDto.User.Vehicle.Year);
        }
    }
}
