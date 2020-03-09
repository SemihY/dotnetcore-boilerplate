using System.Threading.Tasks;

namespace src.Services.Interfaces
{
    public interface ICreditScoreService
    {
        Task<long> GetScore(long id);
    }
}