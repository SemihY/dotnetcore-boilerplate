using System.Threading.Tasks;
using CreditApi.Services.Interfaces;

namespace CreditApi.Services
{
    public class CreditScoreService : ICreditScoreService
    {
        public Task<long> GetScore(long id)
        {
            return Task.FromResult<long>(600);
        }
    }
}