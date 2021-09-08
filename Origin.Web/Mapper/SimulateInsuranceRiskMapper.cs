using Origin.Application.Dtos.Enums;
using Origin.Application.Dtos.Insurance;
using Origin.Application.Dtos.PersonalInfo;
using Origin.Web.Reponses;
using Origin.Web.Requests;
using System;
using System.Linq;

namespace Origin.Web.Mapper
{
    public static class SimulateInsuranceRiskMapper
    {
        public static UserDto MapRequest(this SimulateInsuranceRiskRequest simulateInsuranceRisk) =>
            new UserDto
            {
                Age = simulateInsuranceRisk.Age,
                Dependents = simulateInsuranceRisk.Dependents,
                Income = simulateInsuranceRisk.Income,
                RiskQuestions = simulateInsuranceRisk.RiskQuestions,
                MaritalStatus = Enum.TryParse(simulateInsuranceRisk.MaritalStatus, ignoreCase : true, out MaritalStatus result) ? result : 0,
                House = simulateInsuranceRisk.House?.MapHouse(),
                Vehicle = simulateInsuranceRisk.Vehicle?.MapVehicle()
            };

        public static SimulateInsuranceRiskResponse MapResponse(this InsuranceRiskDto insuranceRiskDto)
        {
            if (insuranceRiskDto is null)
                return null;

            var response = new SimulateInsuranceRiskResponse();

            insuranceRiskDto.Insurances.ForEach(insurance =>
            {
                switch (insurance.Name)
                {
                    case "Auto":
                        response.Auto = insurance.Risk;
                        break;
                    case "Home":
                        response.Home = insurance.Risk;
                        break;
                    case "Disability":
                        response.Disability = insurance.Risk;
                        break;
                    case "Life":
                        response.Life = insurance.Risk;
                        break;
                }
            });

            return response;
        }

        private static HouseDto MapHouse(this HouseRequest house) =>
            new HouseDto
            {
                OwnershipStatus = Enum.TryParse(house.OwnershipStatus, ignoreCase : true, out OwnershipStatus result) ? result : 0
            };

        private static VehicleDto MapVehicle(this VehicleRequest vehicle) =>
            new VehicleDto
            {
                Year = vehicle.Year
            };
    }
}
