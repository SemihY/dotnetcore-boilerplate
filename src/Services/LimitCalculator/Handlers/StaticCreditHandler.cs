using CreditApi.Patterns.Specification;

namespace CreditApi.Services.LimitCalculator.Handlers
{
    public class StaticCreditHandler<T>: IHandler<T>
    {
        private IHandler<T> _successor;
        private ISpecification<T> _specification;

        public StaticCreditHandler(IHandler<T> successor, ISpecification<T> specification)
        {
            this._successor = successor;
            this._specification = specification;
        }

        public void SetSuccessor(IHandler<T> handler)
        {
            throw new System.NotImplementedException();
        }
        
        public bool CanHandle(T o)     {
            return _specification.IsSatisfiedBy(o);
        }
        
        public decimal CalculateLimit(T o)
        {
            if (!CanHandle(o))  {
                return _successor.CalculateLimit(o);
            }

            return 10000;
        }

        public void SetSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }
    }
}