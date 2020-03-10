using System.Threading.Tasks;

namespace CreditApi.Services.Interfaces
{
    public interface ICreditScoreService
    {
        Task<long> GetScore(long id);
    }
}