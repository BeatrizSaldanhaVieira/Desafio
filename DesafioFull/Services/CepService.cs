using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class CepService
{
    private readonly HttpClient _httpClient;

    public CepService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para validar o CEP
    public async Task<bool> ValidarCepAsync(string cep)
    {
        // A URL correta para a API do cep.la
        var response = await _httpClient.GetStringAsync($"http://cep.la/{cep}");

        if (string.IsNullOrEmpty(response))
        {
            return false;
        }

        var endereco = JsonConvert.DeserializeObject<dynamic>(response);

        return endereco != null && endereco.cep != null;
    }
}
