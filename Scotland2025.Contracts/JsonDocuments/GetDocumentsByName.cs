using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scotland2025.Contracts.JsonDocuments;
public static class GetJsonDocumentByName
{
    public record Response(int Id, string DocumentName, string JsonValue, DateTime LastModified);
}
