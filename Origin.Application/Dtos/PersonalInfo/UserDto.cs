using Origin.Application.Dtos.Enums;
using System.Collections.Generic;

namespace Origin.Application.Dtos.PersonalInfo
{
    public class UserDto
    {
        public int? Age { get; set; }
        public int? Dependents { get; set; }        
        public double? Income { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public List<byte> RiskQuestions { get; set; }
        public HouseDto House { get; set; }
        public VehicleDto Vehicle { get; set; }
    }
}
