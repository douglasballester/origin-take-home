using Origin.Application.Dtos.Enums;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Domain.Entities.PersonalInfo;
using DomainEnum = Origin.Domain.Enums;

namespace Origin.Application.Mappers
{
    public static class HouseMapper
    {
        public static House Map(this HouseDto houseDto) =>
            new House((DomainEnum.OwnershipStatus)houseDto.OwnershipStatus);

        public static HouseDto MapDto(this House house) =>
            new HouseDto {
                OwnershipStatus = (OwnershipStatus)house.OwnershipStatus
            };
    }
}
