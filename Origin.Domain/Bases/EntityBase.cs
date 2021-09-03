namespace Origin.Domain.Bases
{
    internal abstract class EntityBase
    {
        public long Id { get; private set; }

        public EntityBase(long id)
        {
            Id = id;
        }
    }
}
