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
        private readonly IBinaryTradeService service;

        public BinaryTradeController(IBinaryTradeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null) return BadRequest("Id is required");

            var item = await service.GetAsync(id);

            if (item == null)
            {
                return NotFound(id);
            }

            return new ObjectResult(item);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Generate()
        {
            var item = await service.GenerateAsync();
            return CreatedAtAction("Generate", new { id = item.Id }, item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AssetTradeViewModel trade)
        {
            var item = await service.SaveAsync(trade);
            return CreatedAtAction("Post", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AssetTradeViewModel trade)
        {
            if (await service.GetAsync(id) == null) return NotFound(id);

            var item = await service.UpdateAsync(id, trade);
            return new OkObjectResult(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await service.GetAsync(id) == null) return NotFound(id);

            var item = await service.DeleteAsync(id);
            return new OkObjectResult(item);
        }
    }
}
