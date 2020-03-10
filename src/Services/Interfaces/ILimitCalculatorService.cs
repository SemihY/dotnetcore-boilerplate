using CreditApi.Modals;

namespace CreditApi.Services.Interfaces
{
    public interface ILimitCalculatorService
    {
        public decimal Calculate(CreditParameters parameters);
    }
}