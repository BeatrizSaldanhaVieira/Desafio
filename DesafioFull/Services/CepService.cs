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

        // Deserializa a resposta em um objeto dinâmico
        var endereco = JsonConvert.DeserializeObject<dynamic>(response);

        // Valida se o retorno não é nulo e se contém os dados necessários
        return endereco != null && endereco.cep != null;
    }
}
