using System.Reflection;
using System.Text.Json;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Portfolio.Code.Utils;

public static class Text
{
    #region FileName attribute for File enum
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    private class FileNameAttribute : Attribute
    {
        public String Name { get; }
        public FileNameAttribute(String name) => Name = name;
    }
    #endregion

    public enum File
    {
        [FileName("common")]
        Common
    }
    
    private const String TEXT_DIRECTORY = "./Text";
    private static String directory = String.Empty;
    private static readonly String DEFAULT_KEY = GetFileEnumDescription(File.Common);

    private static Dictionary<String, Dictionary<String, String>> text = [];
    private static readonly Timer refreshTimer = new();

    // Static constructor to load text from JSON files
    static Text()
    {
        if (text.Count != 0) return;

        if (Directory.Exists(TEXT_DIRECTORY) == false)
        {
            throw new DirectoryNotFoundException($"The directory '{TEXT_DIRECTORY}' does not exist. Please create it and add the necessary JSON files.");
        }

        directory = TEXT_DIRECTORY;

        //Each file will be a key in the outer dictionary, and each JSON key will be a key in the inner dictionary
        //The value of the inner dictionary will be the value of the JSON key
        Array files = Enum.GetValues(typeof(File));

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
        };

        foreach(File file in files)
        {
            String fileName = GetFileEnumDescription(file);
            String fileContents = System.IO.File.ReadAllText($"{directory}/{fileName}.json");
            Dictionary<String, String> fileText = JsonSerializer.Deserialize<Dictionary<String, String>>(fileContents, options)!;
            text.Add(fileName, fileText);
        }

        refreshTimer.Elapsed += RefreshText;
        refreshTimer.Interval = 60000 * 30;//30 minutes
        refreshTimer.AutoReset = true;
        refreshTimer.Enabled = true;
    }
    
    private static void RefreshText(Object? source, ElapsedEventArgs e)
    {
        Task.Run(() =>
        {
            Dictionary<String, Dictionary<String, String>> refreshedText = [];
            Array files = Enum.GetValues(typeof(File));

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
            };

            foreach (File file in files)
            {
                String fileName = GetFileEnumDescription(file);
                String fileContents = System.IO.File.ReadAllText($"{directory}/{fileName}.json");
                Dictionary<String, String> fileText = JsonSerializer.Deserialize<Dictionary<String, String>>(fileContents, options)!;
                refreshedText.Add(fileName, fileText);
            }
            text = refreshedText;
        });
    }

    private static String GetFileEnumDescription(File value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        FileNameAttribute? attribute = (FileNameAttribute)Attribute.GetCustomAttribute(field!, typeof(FileNameAttribute))!;
        return attribute!.Name;
    }
    
    public static String Get(String key)
    {
        try
        {
            return text[DEFAULT_KEY][key];
        }
        catch (KeyNotFoundException)
        {
            if(DebugUtils.IsDebugMode)
            {
                throw new KeyNotFoundException($"Text key {key} not found in {DEFAULT_KEY} file");
            }

            return String.Empty;
        }
    }

    public static String Get(String key, File file)
    {
        try
        {
            return text[GetFileEnumDescription(file)][key];
        }
        catch (KeyNotFoundException)
        {
            if (DebugUtils.IsDebugMode)
            {
                throw new KeyNotFoundException($"Text key {key} not found in {file} file");
            }
                
            return String.Empty;
        }
    }
    
    public static string VersionString
    {
        get
        {
            if (field != null) return field;

            // Read all text from the file
            string jsonString = System.IO.File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json"));

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