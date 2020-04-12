using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace SecurityThreatBrowser
{
    public partial class UserFilePathWindow : Window
    {
        public UserFilePathWindow()
        {
            InitializeComponent();
        }

        private void OnClick(Object sender, RoutedEventArgs e)
        {
            if (OpenManager.OpenFile(PathBox.Text))
                DialogResult = true;
        }
    }
}
