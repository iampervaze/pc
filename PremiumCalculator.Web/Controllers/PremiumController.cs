using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Web.Abstractions.Services;
using PremiumCalculator.Web.Models;

namespace PremiumCalculator.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumCalculatorService premiumCalculatorService;
        public PremiumController(IPremiumCalculatorService _premiumCalculatorService)
        {
            premiumCalculatorService = _premiumCalculatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var premium = await premiumCalculatorService.CalculateInsurancePremiumAsync(customer);
            return Ok(premium);
        }
    }
}
