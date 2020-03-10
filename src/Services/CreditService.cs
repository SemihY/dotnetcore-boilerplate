using System.Threading.Tasks;
using CreditApi.Modals;
using CreditApi.Repositories;
using CreditApi.Repositories.Entities;
using CreditApi.Requests;
using CreditApi.Services.Interfaces;

namespace CreditApi.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditScoreService _creditScoreService;
        private readonly ILimitCalculatorService _limitCalculator;
        private readonly ICreditRepository _creditRepository;

        public CreditService(ICreditScoreService creditScoreService, ILimitCalculatorService limitCalculator, ICreditRepository creditRepository)
        {
            _creditScoreService = creditScoreService;
            _limitCalculator = limitCalculator;
            _creditRepository = creditRepository;
        }

        public async Task<CreditResult> Apply(CreditApplyRequest request)
        {
            var score = await _creditScoreService.GetScore(request.IdentificationNumber);

            var creditParameters = new CreditParameters
            {
                Salary = request.Salary,
                Score = score
            };
            
            var limit = _limitCalculator.Calculate(creditParameters);

            if (limit <= 0) return CreditResult.Fail();
            
            var credit = new Credit
            {
                IdentificationNumber = request.IdentificationNumber,
                Name = request.Name,
                Surname = request.Surname,
                Salary = request.Salary,
                TelephoneNumber = request.TelephoneNumber,
                CreditLimit = limit
            };
            
            await _creditRepository.InsertAsync(credit);

            return CreditResult.Success(limit);
        }
    }
}