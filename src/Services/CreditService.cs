using System.Threading.Tasks;
using src.Modals;
using src.Requests;
using src.Services.Interfaces;

namespace src.Services
{
    public class CreditService : ICreditService
    {
        private readonly ICreditScoreService _creditScoreService;

        public CreditService(ICreditScoreService creditScoreService)
        {
            _creditScoreService = creditScoreService;
        }

        public async Task<CreditResult> Apply(CreditApplyRequest request)
        {
            var score = await _creditScoreService.GetScore(request.IdentificationNumber);

            var limit = 0;

            return limit > 0 ? CreditResult.Success(limit) : CreditResult.Fail();
        }
    }
}