using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using RedisTestCountries.Interfaces;
using Refit;
using System.Net;

namespace Countries.Test
{
    public class CountryTest
    {
        private readonly ICountryAPI _apiCountry;
        private readonly IDistributedCache _distributedCache;

        private HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:5001/")
        };

        public CountryTest(IDistributedCache _distributedCache)
        {
            this._distributedCache = _distributedCache;
            _apiCountry = RestService.For<ICountryAPI>(httpClient);
        }

        [Fact]
        public async void TestApiStatusCodeReturn()
        {
            //Arrange
            
            //Act
            var responseAPI = await _apiCountry.GetAsync();            

            //Assert
            Assert.Equal(HttpStatusCode.OK, responseAPI.StatusCode);
        }

        [Fact]
        public async void TestApiReturnType()
        {
            //Act
            var countryController = new RedisTestCountries.Controllers.CountriesController(_distributedCache);
            var apiResult = await countryController.GetCountries();


            //Assert
            //Assert.Equal(responseType, JTokenType.Array);
            var viewResult = Assert.IsType<JArray>(apiResult);

        }
    }
}