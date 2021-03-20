using BinaryTrade.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BinaryTrade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService service;

        public AssetsController(IAssetService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await service.GetAllAsync());
        }
    }
}
