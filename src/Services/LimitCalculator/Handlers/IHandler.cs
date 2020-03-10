using CreditApi.Patterns.Specification;

namespace CreditApi.Services.LimitCalculator.Handlers
{
    public interface IHandler<T>
    {
        void SetSuccessor(IHandler<T> handler);
        decimal CalculateLimit(T o);
        void SetSpecification(ISpecification<T> specification);
    } 
}