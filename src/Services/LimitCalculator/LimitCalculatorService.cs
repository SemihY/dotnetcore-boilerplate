using CreditApi.Modals;
using CreditApi.Patterns.Specification;
using CreditApi.Services.Interfaces;
using CreditApi.Services.LimitCalculator.Handlers;

namespace CreditApi.Services.LimitCalculator
{
    public class LimitCalculatorService : ILimitCalculatorService
    {
        private IHandler<CreditParameters> rejectHandler;
        
        public LimitCalculatorService()
        {
            IHandler<CreditParameters> defaultHandler = new DefaultHandler<CreditParameters>(null,
                new Specification<CreditParameters>( o => true));
            
            IHandler<CreditParameters> dynamicCreditHandler = new DynamicCreditHandler<CreditParameters>(defaultHandler,
                new Specification<CreditParameters>(x=> x.Score >= 1000));
            
            IHandler<CreditParameters> staticCreditHandler = new StaticCreditHandler<CreditParameters>(dynamicCreditHandler,
                new Specification<CreditParameters>(x=> x.Score >=500 && x.Score < 1000)
                    .And(new Specification<CreditParameters>(x => x.Salary < 5000)));
            
            rejectHandler = new RejectHandler<CreditParameters>(staticCreditHandler,
                new Specification<CreditParameters>(cp => cp.Score < 500));
        }

        public decimal Calculate(CreditParameters parameters)
        {
            return rejectHandler.CalculateLimit(parameters);
        }
    }
}