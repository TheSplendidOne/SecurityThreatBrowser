using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace SecurityThreatBrowser
{
    public partial class UpdateReportWindow : Window
    {
        public UpdateReportWindow(UpdateReport report)
        {
            InitializeComponent();
            AddedNumber.Text = report.AddedThreats.Count.ToString();
            RemovedNumber.Text = report.RemovedThreats.Count.ToString();
            UpdatedNumber.Text = report.UpdateThreatInfos.Count.ToString();
            var addedThreatViewer = new ThreatViewer();
            AddedThreatViewer.Content = addedThreatViewer;
            AddedThreatList.Content = new ThreatList(report.AddedThreats, addedThreatViewer);
            var removedThreatViewer = new ThreatViewer();
            RemovedThreatViewer.Content = removedThreatViewer;
            RemovedThreatList.Content = new ThreatList(report.RemovedThreats, removedThreatViewer);
            var updatedNewThreatViewer = new ThreatViewer();
            var updatedOldThreatViewer = new ThreatViewer();
            UpdatedNewThreatViewer.Content = updatedNewThreatViewer;
            UpdatedOldThreatViewer.Content = updatedOldThreatViewer;
            UpdatedThreatList.Content = new UpdatedThreatList(report.UpdateThreatInfos, updatedOldThreatViewer, updatedNewThreatViewer);
        }

        private void OnClosing(Object sender, CancelEventArgs e)
        {
            DialogResult = true;
        }
    }
}
