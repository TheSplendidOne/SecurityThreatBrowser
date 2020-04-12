using System;
using System.Net;
using System.Windows;

namespace SecurityThreatBrowser
{
    public static class DownloadManager
    {
        public static readonly Uri DefaultUri = new Uri(@"https://bdu.fstec.ru/files/documents/thrlist.xlsx");

        public static Boolean DownloadFile(String filePath)
        {
            try
            {
                using WebClient client = new WebClient();
                client.DownloadFile(DefaultUri, filePath);
                return true;
            }
            catch(Exception ex)
            {
                if(ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, "Не удалось загрузить файл");
                else
                    MessageBox.Show("Отсутствует соединение с интернетом.", "Не удалось загрузить файл");
                return false;
            }
        }
    }
}
