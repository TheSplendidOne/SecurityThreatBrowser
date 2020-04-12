using System;
using System.Windows;

namespace SecurityThreatBrowser
{
    public partial class SelectFileWindow : Window
    {
        public SelectFileWindow()
        {
            InitializeComponent();
            FilesPaths.ItemsSource = SettingsManager.ReadSavedFilesPaths();
        }

        private void OpenSelectedFileOnClick(Object sender, RoutedEventArgs e)
        {
            if(OpenManager.OpenFile((String) FilesPaths.SelectedItem))
                DialogResult = true;
        }

        private void OpenByPathOnClick(Object sender, RoutedEventArgs e)
        {
            var userFilePathWindow = new UserFilePathWindow();
            if (userFilePathWindow.ShowDialog() == true)
                DialogResult = true;
        }
    }
}
