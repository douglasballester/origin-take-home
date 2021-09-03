using System.Collections.Generic;

namespace Origin.Application.Dtos.Insurace
{
    public class SimulateInsuranceRiskRequestDto
    {
        public int Age { get; set; }
        public int Dependents { get; set; }
        public HouseDto House { get; set; }
        public float Income { get; set; }
        public string MaritalStatus { get; set; }
        public List<bool> RiskQuestions { get; set; }
        public VehicleDto Vehicle { get; set; }
    }
}
