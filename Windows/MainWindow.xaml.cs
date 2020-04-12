using System;
using System.Collections.Generic;
using System.Windows;

namespace SecurityThreatBrowser
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;

        public MainWindow(IEnumerable<Threat> threats)
        {
            InitializeComponent();
            var threatViewer = new ThreatViewer();
            MainThreatViewer.Content = threatViewer;
            MainThreatList.Content = new ThreatList(threats, threatViewer);
        }

        private void OpenItemOnClick(Object sender, RoutedEventArgs e)
        {
            new SelectFileWindow().ShowDialog();
        }

        private void DownloadItemOnClick(Object sender, RoutedEventArgs e)
        {
            new DownloadWindow().ShowDialog();
        }

        private void SaveItemOnClick(Object sender, RoutedEventArgs e)
        {
            new SaveToJsonWindow().ShowDialog();
        }

        private void RefreshItemOnClick(Object sender, RoutedEventArgs e)
        {
            UpdateManager.Update();
        }
    }
}
