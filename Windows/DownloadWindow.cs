using System;
using System.IO;
using System.Windows;

namespace SecurityThreatBrowser
{
    public class DownloadWindow : SaveNewFileWindow
    {
        protected override void OnClick(Object sender, RoutedEventArgs e)
        {
            String newFilePath = Path.Combine(DirectoryBox.Text, NameBox.Text) + XlsxThreatReader.DefaultExtension;
            if (DownloadManager.DownloadFile(newFilePath))
            {
                OpenManager.OpenFile(newFilePath);
                DialogResult = true;
            }
        }
    }
}
