//using ErrorOr;
//using Microsoft.EntityFrameworkCore;
//using Scotland2025.Application.Abstractions.Commands;
//using Scotland2025.Application.Abstractions.Data;
//using Scotland2025.Application.Abstractions.DatesAndTime;
//using Scotland2025.Application.Common.Errors;
//using Scotland2025.Application.Images;
//using Scotland2025.Application.JsonDocuments;

//namespace Scotland2025.Application.ImgBB;

//public record UploadImageCommand(string ImageBase64, string Description, string UploadedBy) : ICommand<ErrorOr<Image>>;

//public class UploadImageCommandHandler : ICommandHandler<UploadImageCommand, ErrorOr<Image>>
//{
//    private readonly IScotland2025DbContext _dbContext;
//    private readonly IHttpClientFactory _httpClientFactory;
//    private readonly IDateTimeProvider _dateTimeProvider;

//    public UploadImageCommandHandler(IScotland2025DbContext dbContext, IHttpClientFactory httpClientFactory, IDateTimeProvider dateTimeProvider)
//    {
//        _dbContext = dbContext;
//        _httpClientFactory = httpClientFactory;
//        _dateTimeProvider = dateTimeProvider;
//    }

//    public async Task<ErrorOr<Image>> Handle(UploadImageCommand command, CancellationToken cancellationToken)
//    {
//        var httpClient = _httpClientFactory.CreateClient("ImgBBClient");

//        var apiKey = "5807608c2011ab947b18651729b048e5"; // Replace with your actual API key

//        var payload 

//        var jsonDocument = JsonDocument.Create(command.DocumentName, command.JsonValue, _dateTimeProvider.UtcNow);

//        var existingJsonDocument = await GetJsonDocumentByNameAsync(jsonDocument.DocumentName, cancellationToken);
//        if (existingJsonDocument is not null)
//        {
//            return ApplicationErrors.JsonDocuments.Conflict(jsonDocument.DocumentName);
//        }

//        _dbContext.JsonDocuments.Add(jsonDocument);
//        var result = await _dbContext.SaveChangesAsync(cancellationToken);
//        if (result == 0)
//        {
//            return Error.Failure($"Unable to add {jsonDocument.DocumentName}");
//        }

//        return jsonDocument;
//    }

//}
