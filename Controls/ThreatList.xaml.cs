using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace SecurityThreatBrowser
{
    public partial class ThreatList : UserControl
    {
        protected readonly ThreatViewer _viewer;

        public ThreatList(IEnumerable<Threat> threats, ThreatViewer viewer)
        {
            InitializeComponent();
            DataContext = new ThreatListViewModel(threats);
            _viewer = viewer;
        }

        protected virtual void OnSelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            if(!((ThreatListViewModel)DataContext).PageChangingFlag)
                _viewer.DataContext = Items.SelectedItem as Threat;
        }
    }
}
