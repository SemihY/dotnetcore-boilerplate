using System.Threading.Tasks;
using CreditApi.Modals;
using CreditApi.Requests;

namespace CreditApi.Services.Interfaces
{
    public interface ICreditService
    {
        Task<CreditResult> Apply(CreditApplyRequest request);
    }
}