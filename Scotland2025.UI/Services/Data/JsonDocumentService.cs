using Scotland2025.Contracts.JsonDocuments;
using Scotland2025.UI.Abstractions.Data;
using System.Net.Http.Json;
using System.Text.Json;

namespace Scotland2025.UI.Services.Data;

public class JsonDocumentService : IJsonDocumentService
{
    private readonly ILogger<JsonDocumentService> _logger;
    private readonly HttpClient _httpClient;

    public JsonDocumentService(ILogger<JsonDocumentService> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public async Task<T?> GetJsonDocumentByIdAsync<T>(int id, CancellationToken cancellationToken = default)
    {
        var endpoint = $"jsonDocuments/{id}";

        return await GetJsonDocumentsAsync<T>(endpoint, cancellationToken);

    }

    public async Task<T?> GetJsonDocumentByNameAsync<T>(string documentName, CancellationToken cancellationToken = default)
    {
        var endpoint = $"jsonDocuments/find/{documentName}";

        return await GetJsonDocumentsAsync<T>(endpoint, cancellationToken);
    }


    private async Task<T?> GetJsonDocumentsAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Calling endpoint: {_httpClient.BaseAddress}{endpoint}");
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var response = await _httpClient.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        var jd = JsonSerializer.Deserialize<GetJsonDocumentByName.Response>(content, options);
        var jsonDocumentResponse = await _httpClient.GetFromJsonAsync<GetJsonDocumentByName.Response>(endpoint, options, cancellationToken);
        if (jsonDocumentResponse == null)
        {
            _logger.LogError("Failed to retrieve json document data from endpoint = {endpoint}.", endpoint);
            return default;
        }

        return JsonSerializer.Deserialize<T>(jsonDocumentResponse.JsonValue, options);
    }
}
