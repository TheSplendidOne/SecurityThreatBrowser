using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SecurityThreatBrowser
{
    public class UpdatedThreatList : ThreatList
    {
        private readonly ThreatViewer _newThreatViewer;

        private readonly List<UpdateThreatInfo> _infos;

        public UpdatedThreatList(List<UpdateThreatInfo> infos, ThreatViewer oldThreatViewer, ThreatViewer newThreatViewer)
            : base(infos.Select(info => info.OldThreat), oldThreatViewer)
        {
            _newThreatViewer = newThreatViewer;
            _infos = infos;
        }

        protected override void OnSelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            if (!((ThreatListViewModel) DataContext).PageChangingFlag)
            {
                _viewer.DataContext = Items.SelectedItem as Threat;
                _newThreatViewer.DataContext = _infos?.Find(info => info.OldThreat.Equals(Items.SelectedItem as Threat))?.NewThreat;
                if(Items.SelectedItem != null)
                    SetAllTextBlocksVisibility();
            }
        }

        private void SetAllTextBlocksVisibility()
        {
            _viewer.Id.Visibility = _viewer.IdValue.Visibility = _newThreatViewer.Id.Visibility =
                _newThreatViewer.IdValue.Visibility = _viewer.IdValue.Text == _newThreatViewer.IdValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Name.Visibility = _viewer.NameValue.Visibility = _newThreatViewer.Name.Visibility =
                _newThreatViewer.NameValue.Visibility = _viewer.NameValue.Text == _newThreatViewer.NameValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Description.Visibility = _viewer.DescriptionValue.Visibility = _newThreatViewer.Description.Visibility =
                _newThreatViewer.DescriptionValue.Visibility = _viewer.DescriptionValue.Text == _newThreatViewer.DescriptionValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Source.Visibility = _viewer.SourceValue.Visibility = _newThreatViewer.Source.Visibility =
                _newThreatViewer.SourceValue.Visibility = _viewer.SourceValue.Text == _newThreatViewer.SourceValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Target.Visibility = _viewer.TargetValue.Visibility = _newThreatViewer.Target.Visibility =
                _newThreatViewer.TargetValue.Visibility = _viewer.TargetValue.Text == _newThreatViewer.TargetValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Confidentiality.Visibility = _viewer.ConfidentialityValue.Visibility = _newThreatViewer.Confidentiality.Visibility =
                _newThreatViewer.ConfidentialityValue.Visibility = _viewer.ConfidentialityValue.Text == _newThreatViewer.ConfidentialityValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Integrity.Visibility = _viewer.IntegrityValue.Visibility = _newThreatViewer.Integrity.Visibility =
                _newThreatViewer.IntegrityValue.Visibility = _viewer.IntegrityValue.Text == _newThreatViewer.IntegrityValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.Availability.Visibility = _viewer.AvailabilityValue.Visibility = _newThreatViewer.Availability.Visibility =
                _newThreatViewer.AvailabilityValue.Visibility = _viewer.AvailabilityValue.Text == _newThreatViewer.AvailabilityValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.AdditionDate.Visibility = _viewer.AdditionDateValue.Visibility = _newThreatViewer.AdditionDate.Visibility =
                _newThreatViewer.AdditionDateValue.Visibility = _viewer.AdditionDateValue.Text == _newThreatViewer.AdditionDateValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            _viewer.ChangeDate.Visibility = _viewer.ChangeDateValue.Visibility = _newThreatViewer.ChangeDate.Visibility =
                _newThreatViewer.ChangeDateValue.Visibility = _viewer.ChangeDateValue.Text == _newThreatViewer.ChangeDateValue.Text
                    ? Visibility.Collapsed
                    : Visibility.Visible;
        }
    }
}
