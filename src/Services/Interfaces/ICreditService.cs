using System.Threading.Tasks;
using src.Modals;
using src.Requests;

namespace src.Services.Interfaces
{
    public interface ICreditService
    {
        Task<CreditResult> Apply(CreditApplyRequest request);
    }
}