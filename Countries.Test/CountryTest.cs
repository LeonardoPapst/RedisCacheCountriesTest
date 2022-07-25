using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Newtonsoft.Json.Linq;

namespace Countries.Test
{
    public class CountryTest
    {
        private readonly Mock<IDistributedCache> _distributedCache;

        public CountryTest()
        {
            _distributedCache = new Mock<IDistributedCache>();
        }

        [Fact]
        public async void TestApiStatusCodeReturn()
        {
            //Arrange

            //Act
            var countryController = new RedisTestCountries.Controllers.CountriesController(_distributedCache.Object);
            var responseAPI = await countryController.GetCountries();


            //Assert
            responseAPI.Should().BeOfType<OkObjectResult>();

        }

        [Fact]
        public async void TestApiResponseTipe()
        {
            //Arrange

            //Act
            var countryController = new RedisTestCountries.Controllers.CountriesController(_distributedCache.Object);
            var responseAPI = await countryController.GetCountries();


            //Assert
            responseAPI.Should().As<JArray>();

        }

    }
}