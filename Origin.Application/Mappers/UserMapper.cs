using Origin.Application.Dtos.Enums;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Domain.Entities.PersonalInfo;
using DomainEnum = Origin.Domain.Enums;

namespace Origin.Application.Mappers
{
    public static class UserMapper
    {
        public static User Map(this UserDto userDto) =>
            new User(userDto.Age,
                     userDto.Dependents,
                     userDto.Income,
                     (DomainEnum.MaritalStatus)userDto.MaritalStatus,
                     userDto.RiskQuestions,
                     userDto.House?.Map(),
                     userDto.Vehicle?.Map());

        public static UserDto MapDto(this User user) =>
            new UserDto { 
                Age = user.Age,
                Dependents = user.Dependents,
                Income = user.Income,
                MaritalStatus = (MaritalStatus)user.MaritalStatus,
                RiskQuestions = user.RiskQuestions,
                Vehicle = user.Vehicle?.MapDto(),
                House = user.House?.MapDto(),
            };
    }
}
