using System.Text.Json;

namespace Portfolio.Code.Utils;

public class Text
{
    public static string VersionString
    {
        get
        {
            if (field != null) return field;

            // Read all text from the file
            string jsonString = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json"));

            // Deserialize JSON into a dictionary
            var versionData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);

            int majorVersion = versionData!["MajorVersion"].GetInt32();
            int minorVersion = versionData["MinorVersion"].GetInt32();
            int patchNumber = versionData["PatchNumber"].GetInt32();
            int buildNumber = versionData["BuildNumber"].GetInt32();
            string lastCommitId =
                DebugUtils.IsDebugMode ? $" ({versionData["LastCommitID"].GetString()!})" : String.Empty;

            field = $"v{majorVersion}.{minorVersion}.{patchNumber}:{buildNumber}{lastCommitId}";
            return field;
        }
    } = null;
}