using System.Collections.Generic;

namespace Origin.Domain.Bases
{
    public class ValidationRules<TTarget, TEntity>
    {
        private readonly ICollection<IRule<TTarget, TEntity>> _rules;
        private readonly TTarget _target;
        private readonly TEntity _entity;

        public ValidationRules(TTarget target, TEntity entity)
        {
            _rules = new List<IRule<TTarget, TEntity>>();
            _target = target;
            _entity = entity;
        }

        public ValidationRules<TTarget, TEntity> Add(IRule<TTarget, TEntity> rule)
        {
            _rules.Add(rule);
            
            return this;
        }

        public void Run()
        {
            foreach (var item in _rules)
            {
                item.Validate(_target, _entity);
            }
        }        
    }
}
