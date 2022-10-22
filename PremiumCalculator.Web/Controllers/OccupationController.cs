using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Web.Abstractions.Repository;

namespace PremiumCalculator.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationRepository repo;
        public OccupationController(IOccupationRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await repo.GetOccupationsAsync();
            return Ok(response);
        }
    }
}
