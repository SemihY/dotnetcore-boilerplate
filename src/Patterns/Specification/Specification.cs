using System;

namespace CreditApi.Patterns.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        private readonly Func<T, bool> _expression;
        public Specification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            else
                this._expression = expression;
        }
 
        public bool IsSatisfiedBy(T o)
        {
            return this._expression(o);
        }
    }
}