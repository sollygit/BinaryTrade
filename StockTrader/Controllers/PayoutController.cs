using BinaryTrade.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BinaryTrade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayoutController : ControllerBase
    {
        private readonly IPayoutService service;

        public PayoutController(IPayoutService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await service.GetAsync());
        }
    }
}
