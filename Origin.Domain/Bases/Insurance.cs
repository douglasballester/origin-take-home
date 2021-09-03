using Origin.Domain.Entities.PersonalInfo;

namespace Origin.Domain.Bases
{
    public abstract class Insurance
    {
        public abstract string Name { get; }
        public int Score { get; private set; }
        public bool Ineligible { get; private set; }

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

        public abstract void RunValidations(User user);
    }
}
