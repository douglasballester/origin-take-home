using Origin.Domain.Enums;
using System.Collections.Generic;

namespace Origin.Domain.Entities.PersonalInfo
{
    public class User
    {
        public int Age { get; private set; }
        public short Dependents { get; private set; }
        public double Income { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public List<bool> RiskQuestions { get; private set; }
        public House House { get; private set; }
        public Vehicle Vehicle { get; private set; }
    }
}
