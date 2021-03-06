
using MinimalApis.Entities;

namespace MinimalApis.Services
{
    public class WaffleIngredientService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://gist.githubusercontent.com/Layla-P/022fafeec13bf17cea3ac0c7bd515e94/raw/bf009d953a9df8a0f7932885b374eff51500c04f/waffleIngredients.json";
        public WaffleIngredientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<OrderTopping>> GetIngredients()
        { 
            var responseString = await _httpClient.GetFromJsonAsync<List<OrderTopping>>(URL);
            
            return responseString ?? new List<OrderTopping>();
        }
    }
}
