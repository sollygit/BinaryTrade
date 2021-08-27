using BinaryTrade.Common;
using BinaryTrade.Services;
using BinaryTrade.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BinaryTrade.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BinaryTradeController : ControllerBase
    {
        private readonly IBinaryTradeService tradeService;
        private readonly IAssetService assetService;

        public BinaryTradeController(IBinaryTradeService tradeService, IAssetService assetService)
        {
            this.tradeService = tradeService;
            this.assetService = assetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await tradeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null) return BadRequest("Id is required");

            var item = await tradeService.GetAsync(id);

            if (item == null)
            {
                return NotFound(id);
            }

            return new ObjectResult(item);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Generate()
        {
            var item = await tradeService.GenerateAsync();
            return CreatedAtAction("Generate", new { id = item.Id }, item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AssetTradeViewModel trade)
        {
            var item = await tradeService.SaveAsync(trade);
            return CreatedAtAction("Post", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AssetTradeViewModel trade)
        {
            if (await tradeService.GetAsync(id) == null) return NotFound(id);

            var item = await tradeService.UpdateAsync(id, trade);
            return new OkObjectResult(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await tradeService.GetAsync(id) == null) return NotFound(id);

            var item = await tradeService.DeleteAsync(id);
            return new OkObjectResult(item);
        }

        [HttpGet("Assets")]
        public async Task<IActionResult> Assets()
        {
            return Ok(await assetService.GetAllAsync());
        }

        [HttpGet("Payout")]
        public async Task<IActionResult> Payout()
        {
            return Ok(await assetService.GetPayoutAsync());
        }

        [HttpGet("Directions")]
        public async Task<IActionResult> GetDirectionsAsync()
        {
            return Ok(await Task.FromResult(Constants.DIRECTIONS));
        }
    }
}
