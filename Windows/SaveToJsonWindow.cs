using System;
using System.IO;
using System.Windows;

namespace SecurityThreatBrowser
{
    public class SaveToJsonWindow : SaveNewFileWindow
    {
        protected override void OnClick(Object sender, RoutedEventArgs e)
        {
            if(SaveManager.SaveToJson(Path.Combine(DirectoryBox.Text, NameBox.Text) + JsonThreatReader.DefaultExtension,
                ((ThreatListViewModel)((ThreatList)MainWindow.Instance.MainThreatList.Content).DataContext).AllThreats))
                DialogResult = true;
        }
    }
}
