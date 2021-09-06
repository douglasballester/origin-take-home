using Origin.Application.Dtos.PersonalInfo;
using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Application.Mappers
{
    public static class VehicleMapper
    {
        public static Vehicle Map(this VehicleDto vehicleDto) =>
            new Vehicle(vehicleDto.Year);

        public static VehicleDto MapDto(this Vehicle vehicle) =>
            new VehicleDto { 
                Year = vehicle.Year
            };
    }
}
