using AutoMapper;
using BinaryTrade.Model;
using BinaryTrade.Repository;
using BinaryTrade.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryTrade.Services
{
    public interface IBinaryTradeService
    {
        Task<IEnumerable<AssetTrade>> GetAllAsync();
        Task<AssetTrade> GetAsync(Guid id);
        Task<AssetTrade> SaveAsync(AssetTradeViewModel entity);
        Task<AssetTrade> UpdateAsync(Guid id, AssetTradeViewModel entity);
        Task<AssetTrade> DeleteAsync(Guid id);
    }

    public class BinaryTradeService : IBinaryTradeService
    {
        private readonly IBinaryTradeRepository repository;

        public BinaryTradeService(IBinaryTradeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<AssetTrade>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<AssetTrade> GetAsync(Guid id)
        {
            var all = await repository.GetAllAsync();
            return all.SingleOrDefault(o => o.Id == id.ToString());
        }

        public async Task<AssetTrade> SaveAsync(AssetTradeViewModel entity)
        {
            if (entity == null) throw new ServiceException("Entity cannot be null");

            return await repository.SaveAsync(Mapper.Map<AssetTrade>(entity));
        }

        public async Task<AssetTrade> UpdateAsync(Guid id, AssetTradeViewModel entity)
        {
            return await repository.UpdateAsync(id, Mapper.Map<AssetTrade>(entity));
        }

        public async Task<AssetTrade> DeleteAsync(Guid id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
