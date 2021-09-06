using Origin.Domain.Enums;
using System.Collections.Generic;

namespace Origin.Domain.Entities.PersonalInfo
{
    public class User
    {
        public int Age { get; private set; }
        public int Dependents { get; private set; }
        public double Income { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public List<byte> RiskQuestions { get; private set; }
        public House House { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public User(int age, int dependents, double income, MaritalStatus maritalStatus, List<byte> riskQuestions, House house, Vehicle vehicle)
        {
            Age = age;
            Dependents = dependents;
            Income = income;
            MaritalStatus = maritalStatus;
            RiskQuestions = riskQuestions;
            House = house;
            Vehicle = vehicle;
        }
    }
}
