using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json.Linq;
using Refit;

namespace RedisTestCountries.Interfaces
{
    public interface ICountryAPI
    {
        [Get("/api/Countries")]
        Task<ApiResponse<JArray>> GetAsync();

        
    }
}
