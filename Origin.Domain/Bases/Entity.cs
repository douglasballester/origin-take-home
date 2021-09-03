namespace Origin.Domain.Bases
{
    internal abstract class Entity
    {
        public long Id { get; private set; }

        public Entity(long id)
        {
            Id = id;
        }
    }
}
