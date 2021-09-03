namespace Origin.Domain.Bases
{
    public interface IRule<in TTarget, in TEntity>
    {
        void Validate(TTarget target, TEntity entity);
    }
}
