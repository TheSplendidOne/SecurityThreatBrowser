using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace SecurityThreatBrowser
{
    public static class JsonThreatReader
    {
        public const String DefaultExtension = ".json";

        public static Boolean ReadThreats(String filePath, out IEnumerable<Threat> threats)
        {
            try
            {
                using var reader = new StreamReader(new FileStream(filePath, FileMode.Open));
                threats = JsonConvert.DeserializeObject<List<Threat>>(reader.ReadToEnd());
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Не удалось прочитать файл");
                threats = null;
                return false;
            }
        }
    }
}
