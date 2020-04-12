using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace SecurityThreatBrowser
{
    public static class UpdateManager
    {
        public static void Update()
        {
            var oldThreats =
                ((ThreatListViewModel) ((ThreatList) MainWindow.Instance.MainThreatList.Content).DataContext)
                .AllThreats;
            String tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(OpenManager.OpenedFilePath));
            if(!DownloadManager.DownloadFile(tempPath))
                return;
            if(!XlsxThreatReader.ReadThreats(tempPath, out IEnumerable<Threat> temp))
                return;
            var newThreats = temp.ToList();
            var updateReport = UpdateReport.CreateUpdateReport(oldThreats, newThreats);
            var newMainWindow = new MainWindow(newThreats);
            newMainWindow.Show();
            MainWindow.Instance.Close();
            MainWindow.Instance = newMainWindow;
            try
            {
                UpdateFile(OpenManager.OpenedFilePath, tempPath, newThreats);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Не удалось обновить файл");
                return;
            }
            new UpdateReportWindow(updateReport).ShowDialog();
        }

        private static void UpdateFile(String currentPath, String tempPath, List<Threat> threats)
        {
            switch(Path.GetExtension(currentPath))
            {
                case XlsxThreatReader.DefaultExtension:
                    UpdateXlsxFile(currentPath, tempPath);
                    return;
                case JsonThreatReader.DefaultExtension:
                    UpdateJsonFile(currentPath, tempPath, threats);
                    return;
                default:
                    UpdateJsonFile(currentPath, tempPath, threats);
                    return;
            }
        }

        private static void UpdateXlsxFile(String currentPath, String tempPath)
        {
            File.Delete(currentPath);
            File.Copy(tempPath, currentPath);
            File.Delete(tempPath);
        }

        private static void UpdateJsonFile(String currentPath, String tempPath, List<Threat> threats)
        {
            SaveManager.SaveToJson(currentPath, threats);
            File.Delete(tempPath);
        }
    }
}
