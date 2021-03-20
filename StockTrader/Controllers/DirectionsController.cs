using BinaryTrade.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BinaryTrade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectionsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await Task.FromResult(Constants.DIRECTIONS));
        }
    }
}
