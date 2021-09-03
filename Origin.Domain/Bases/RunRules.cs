namespace Origin.Domain.Bases
{
    public static class RunRules
    {
        public static ValidationRules<TTarget, TEntity> For<TTarget, TEntity>(TTarget target, TEntity entity)
        {
            return new ValidationRules<TTarget, TEntity>(target, entity);
        }
    }
}
