using BinaryTrade.Model;
using BinaryTrade.Settings;
using System.Net;
using System.Threading.Tasks;

namespace BinaryTrade.Services
{
    public interface IPayoutService
    {
        Task<decimal> GetAsync();
    }

    public class PayoutService : IPayoutService
    {
        private readonly TradeSettings settings;

        public PayoutService(TradeSettings settings)
        {
            this.settings = settings;
        }

        public async Task<decimal> GetAsync()
        {
            if (settings.Payout < 0) throw new ServiceException(HttpStatusCode.BadRequest, $"Payout has negative value {settings.Payout}");

            return await Task.FromResult(settings.Payout);
        }
    }
}
