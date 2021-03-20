using BinaryTrade.Services;
using BinaryTrade.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinaryTrade.UnitTest
{
    [TestFixture]
    public class AssetServiceTest
    {
        private IQueryable<AssetViewModel> assets;

        [SetUp]
        public void Setup()
        {
            assets = new List<AssetViewModel>() 
            {
                new AssetViewModel(){ Id = 1, Name = "EUR/USD" },
                new AssetViewModel(){ Id = 2, Name = "JPY/USD" },
                new AssetViewModel(){ Id = 3, Name = "GBP/USD" }
            }.AsQueryable();
        }

        [Test]
        public async Task GetAllAsync_Success()
        {
            // Arrange
            var mockService = new Mock<IAssetService>();
            mockService.Setup(x => x.GetAllAsync()).Returns(async () =>
            {
                await Task.Yield();
                return assets;
            });

            // Act
            var actual = await mockService.Object.GetAllAsync();

            // Assert
            Assert.AreEqual(assets.Count(), actual.Count());
        }

    }
}
