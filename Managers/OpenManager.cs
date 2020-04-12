using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SecurityThreatBrowser
{
    public static class OpenManager
    {
        public static String OpenedFilePath { get; private set; }

        public static Boolean OpenFile(String filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                try
                {
                    if(!ReadThreats(fileInfo, out IEnumerable<Threat> threats))
                        return false;
                    SettingsManager.AddFilePath(filePath);
                    UpdateMainWindow(threats);
                    OpenedFilePath = filePath;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Не удалось открыть файл");
                    return false;
                }
            }
            SettingsManager.RemoveInvalidFilePath(fileInfo.FullName);
            MessageBox.Show($"Файла {fileInfo.FullName} не существует.", "Не удалось открыть файл");
            return false;
        }

        private static Boolean ReadThreats(FileInfo fileInfo, out IEnumerable<Threat> threats)
        {
            switch (fileInfo.Extension)
            {
                case XlsxThreatReader.DefaultExtension:
                    return XlsxThreatReader.ReadThreats(fileInfo.FullName, out threats);
                case JsonThreatReader.DefaultExtension:
                    return JsonThreatReader.ReadThreats(fileInfo.FullName, out threats);
                default:
                    return JsonThreatReader.ReadThreats(fileInfo.FullName, out threats);
            }
        }

        private static void UpdateMainWindow(IEnumerable<Threat> threats)
        {
            var newMainWindow = new MainWindow(threats);
            newMainWindow.Show();
            MainWindow.Instance?.Close();
            MainWindow.Instance = newMainWindow;
        }
    }
}
