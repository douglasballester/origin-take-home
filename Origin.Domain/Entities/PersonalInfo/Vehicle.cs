namespace Origin.Domain.Entities.PersonalInfo
{
    public class Vehicle
    {
        public int Year { get; private set; }

        public Vehicle(int year)
        {
            Year = year;
        }
    }
}
