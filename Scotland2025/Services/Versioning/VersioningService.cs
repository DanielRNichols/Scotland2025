using Scotland2025.Abstractions.Versioning;

namespace Scotland2025.Versioning
{
    public class VersioningService : IVersioningService
    {
        public string GetVersion()
        {
            var version = "0.9.0";
            var releaseCandidate = "";
            return $"Version {version} {releaseCandidate}";
        }
    }
}
