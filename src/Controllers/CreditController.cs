using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Entities;
using src.Enums;
using src.Repositories;
using src.Requests;
using src.Services.Interfaces;

namespace src.Controllers
{
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ILogger<CreditController> _logger;
        private readonly ICreditService _creditService;
        private readonly ICreditRepository _creditRepository;

        public CreditController(ILogger<CreditController> logger, ICreditService creditService,
            ICreditRepository creditRepository)
        {
            _logger = logger;
            _creditService = creditService;
            _creditRepository = creditRepository;
        }

        [HttpPost]
        [Route("apply")]
        public async Task<IActionResult> Apply([FromBody] CreditApplyRequest request)
        {
            var creditResult = await _creditService.Apply(request);

            if (creditResult.Status == CreditStatus.NotApplied)
            {
                return BadRequest(creditResult);
            }

            var credit = new Credit
            {
                IdentificationNumber = request.IdentificationNumber,
                Name = request.Name,
                Surname = request.Surname,
                Salary = request.Salary,
                TelephoneNumber = request.TelephoneNumber,
                CreditLimit = creditResult.Limit
            };
            
            await _creditRepository.InsertAsync(credit);

            return Ok(creditResult);
        }
    }
}