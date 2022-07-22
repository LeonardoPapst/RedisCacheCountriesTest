using Moq;
using Newtonsoft.Json.Linq;
using RedisTestCountries.Interfaces;
using Refit;
using System.Net;

namespace Countries.Test
{
    public class CountryTest
    {
        private readonly ICountryAPI _apiCountry;
        private HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:8080/")
        };

        public CountryTest()
        {
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
    }
}