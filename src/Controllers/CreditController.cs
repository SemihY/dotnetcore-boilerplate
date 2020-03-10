using System.Threading.Tasks;
using CreditApi.Enums;
using CreditApi.Requests;
using CreditApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditApi.Controllers
{
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
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

            return Ok(creditResult);
        }
    }
}