using System;
using System.Windows;

namespace SecurityThreatBrowser
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void OpenFileOnClick(Object sender, RoutedEventArgs e)
        {
            var selectFileWindow = new SelectFileWindow();
            if(selectFileWindow.ShowDialog() == true)
                Close();
        }

        private void DownloadFileOnClick(Object sender, RoutedEventArgs e)
        {
            var downloadWindow = new DownloadWindow();
            if(downloadWindow.ShowDialog() == true)
                Close();
        }
    }
}
