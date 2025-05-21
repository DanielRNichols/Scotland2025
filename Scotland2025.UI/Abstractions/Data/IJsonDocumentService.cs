namespace Scotland2025.UI.Abstractions.Data;

public interface IJsonDocumentService<T> where T : class
{
    Task<T?> GetJsonDocumentByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<T?> GetJsonDocumentByNameAsync(string documentName, CancellationToken cancellationToken = default);
}
