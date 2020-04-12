using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SecurityThreatBrowser
{
    public static class SettingsManager
    {
        private const String DefaultSettingsFilePath = "settings.json";

        public static Boolean IsSettingsFileExist()
        {
            return File.Exists(DefaultSettingsFilePath);
        }

        public static void CreateSettingsFile()
        {
            using var writer = new StreamWriter(new FileStream(DefaultSettingsFilePath, FileMode.Create));
            writer.Write(JsonConvert.SerializeObject(new List<String>()));
        }

        public static void CreateSettingsFileIfDoesNotExist()
        {
            if(!IsSettingsFileExist())
                CreateSettingsFile();
        }

        public static List<String> ReadSavedFilesPaths()
        {
            CreateSettingsFileIfDoesNotExist();
            using var reader = new StreamReader(new FileStream(DefaultSettingsFilePath, FileMode.Open));
            return JsonConvert.DeserializeObject<List<String>>(reader.ReadToEnd());
        }

        public static void AddFilePath(String path)
        {
            List<String> paths = ReadSavedFilesPaths();
            if (paths.Contains(path))
                return;
            paths.Add(path);
            using var writer = new StreamWriter(new FileStream(DefaultSettingsFilePath, FileMode.Truncate));
            writer.Write(JsonConvert.SerializeObject(paths));
        }

        public static void RemoveInvalidFilePath(String path)
        {
            List<String> paths = ReadSavedFilesPaths();
            paths.Remove(path);
            using var writer = new StreamWriter(new FileStream(DefaultSettingsFilePath, FileMode.Truncate));
            writer.Write(JsonConvert.SerializeObject(paths));
        }
    }
}
