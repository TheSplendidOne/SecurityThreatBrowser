using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace SecurityThreatBrowser
{
    public static class SaveManager
    {
        public static Boolean SaveToJson(String path, List<Threat> threats)
        {
            try
            {
                using var writer = new StreamWriter(new FileStream(path, FileMode.Create));
                writer.Write(JsonConvert.SerializeObject(threats));
                SettingsManager.AddFilePath(path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Не удалось сохранить файл");
                return false;
            }
        }
    }
}
