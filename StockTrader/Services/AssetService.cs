using AutoMapper;
using BinaryTrade.Common;
using BinaryTrade.Model;
using BinaryTrade.Repository;
using BinaryTrade.Settings;
using BinaryTrade.ViewModels;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BinaryTrade.Services
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetViewModel>> GetAllAsync();
        Task<decimal> GetPayoutAsync();
    }

    public class AssetService : IAssetService
    {
        private readonly IMemoryCache cache;
        private readonly TradeSettings settings;
        private readonly IBinaryTradeRepository repository;

        public AssetService(IMemoryCache cache, TradeSettings settings, IBinaryTradeRepository repository)
        {
            this.cache = cache;
            this.settings = settings;
            this.repository = repository;
        }

        public async Task<IEnumerable<AssetViewModel>> GetAllAsync()
        {
            return await cache.GetOrCreateAsync("AssetList", async e => 
            {
                // Cache Assets
                e.SetOptions(new MemoryCacheEntryOptions{ AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1) });

                var currencyPairs = repository.CurrencyPairList();
                var result = currencyPairs.Select(pair => Mapper.Map<AssetViewModel>(new Asset((int)pair, pair.Description())));
                return await Task.FromResult(result);
            });
        }

        public async Task<decimal> GetPayoutAsync()
        {
            if (settings.Payout < 0) 
                throw new ServiceException(HttpStatusCode.BadRequest, $"Payout can't be negative {settings.Payout}");

            return await Task.FromResult(settings.Payout);
        }
    }
}
