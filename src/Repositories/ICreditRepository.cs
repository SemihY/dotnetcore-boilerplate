using System.Threading.Tasks;
using src.Entities;

namespace src.Repositories
{
    public interface ICreditRepository
    {
        Task<Credit> InsertAsync(Credit credit);
    }
}