using BinaryTrade.Common;
using BinaryTrade.Model;
using Bogus;
using System;
using System.Collections.Generic;

namespace BinaryTrade.Repository
{
    public static class MockUtil
    {
        public static IEnumerable<CurrencyPair> CurrencyPairs = (IEnumerable<CurrencyPair>)Enum.GetValues(typeof(CurrencyPair));

        public static List<AssetTrade> Trades(int count)
        {
            var trades = new Faker<AssetTrade>()
                .RuleFor(o => o.Id, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Asset, f => {
                    var pair = new Faker().Random.ListItem((IList<CurrencyPair>)CurrencyPairs);
                    return new Asset((int)pair, pair.Description());
                })
                .RuleFor(o => o.Amount, f => decimal.Parse(f.Random.Decimal(1000).ToString("0.00")))
                .RuleFor(o => o.Expiration, f => f.Random.Number(1, 1000))
                .RuleFor(o => o.Payout, f => f.Random.Number(1, 1000))
                .RuleFor(o => o.Direction, f => f.Random.Number(0, 1))
                .Generate(count);
            return trades;
        }
    }
}
