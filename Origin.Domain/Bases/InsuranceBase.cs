using System.Collections.Generic;

namespace Origin.Domain.Bases
{
    internal abstract class InsuranceBase
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public bool Ineligible { get; private set; }
        public List<RuleBase> Rules { get; private set; }
    }
}
