using Scotland2025.Application.Abstractions.Versioning;

namespace Scotland2025.Services.Versioning
{
    public class VersioningService : IVersioningService
    {
        public string GetVersion()
        {
            var version = "0.1.0";
            var releaseCandidate = "";
            return $"Version {version} {releaseCandidate}";
        }
    }
}
