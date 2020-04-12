using System;
using System.Windows;

namespace SecurityThreatBrowser
{
    public abstract partial class SaveNewFileWindow : Window
    {
        protected SaveNewFileWindow()
        {
            InitializeComponent();
        }

        protected abstract void OnClick(Object sender, RoutedEventArgs e);
    }
}
