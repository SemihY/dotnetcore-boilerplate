using System.Threading.Tasks;
using CreditApi.Repositories.Entities;

namespace CreditApi.Repositories
{
    public interface ICreditRepository
    {
        Task<Credit> InsertAsync(Credit credit);
    }
}