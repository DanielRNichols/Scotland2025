namespace Scotland2025.UI.Abstractions.Data;

public interface IJsonDocumentService
{
    Task<T?> GetJsonDocumentByIdAsync<T>(int id, CancellationToken cancellationToken = default);
    Task<T?> GetJsonDocumentByNameAsync<T>(string documentName, CancellationToken cancellationToken = default);
}
