using System.Threading.Tasks;
using src.Services.Interfaces;

namespace src.Services
{
    public class CreditScoreService : ICreditScoreService
    {
        public Task<long> GetScore(long id)
        {
            return Task.FromResult<long>(12);
        }
    }
}