using System.Threading.Tasks;
using CreditApi.Repositories;
using Microsoft.Extensions.Logging;
using src.Entities;

namespace src.Repositories
{
    public class CreditRepository : ICreditRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<CreditRepository> _logger;

        public CreditRepository(DataContext dataContext, ILogger<CreditRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Credit> InsertAsync(Credit credit)
        {
            _dataContext.Add(credit);
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _logger.LogError($"Error in {nameof(InsertAsync)}: " + exp.Message);
            }

            return credit;
        }
    }
}