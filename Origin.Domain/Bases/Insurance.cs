using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Bases
{
    public abstract class Insurance
    {
        public abstract string Name { get; }
        public int Score { get; private set; }
        public bool Ineligible { get; private set; }
        public string Risk => GetRiskResult();

        public Insurance(int score)
        {
            Score = score;
        }

        internal void DeductScore(int deduct)
        {
            Score -= deduct;
        }

        internal void AddScore(int add)
        {
            Score += add;
        }

        internal void SetIneligible()
        {
            Ineligible = true;
        }

        internal virtual string GetRiskResult()
        {
            if (Ineligible)
                return "ineligible";

            switch (Score)
            {
                case <= 0:
                    return "economic";
                case 1:
                case 2:
                    return "regular";
                case >= 3:
                    return "responsible";
            };                
        }

        public abstract void RunValidations(User user);
    }
}
