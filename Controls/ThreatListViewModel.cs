using System;
using System.Collections.Generic;
using System.Linq;

namespace SecurityThreatBrowser
{
    public class ThreatListViewModel : ViewModelBase
    {
        private const Int32 ThreatsOnPage = 15;

        public Boolean PageChangingFlag { get; private set; }

        public List<Threat> AllThreats { get; }

        private List<Threat> _threats;

        public List<Threat> Threats
        {
            get => _threats;
            set
            {
                _threats = value;
                OnPropertyChanged();
            }
        }

        private Int32 _page;

        public Int32 Page
        {
            get => _page;
            set
            {
                _page = value;
                OnPropertyChanged();
            }
        }

        private Int32 _pagesNumber;

        public Int32 PagesNumber
        {
            get => _pagesNumber;
            set
            {
                _pagesNumber = value;
                OnPropertyChanged();
            }
        }

        public ThreatListViewModel(IEnumerable<Threat> threats)
        {
            AllThreats = threats.ToList();
            Page = AllThreats.Count == 0 ? 0 : 1;
            Threats = AllThreats.Take(ThreatsOnPage).ToList();
            PagesNumber = (Int32)Math.Ceiling((Double) AllThreats.Count / ThreatsOnPage);
        }

        private RelayCommand _goForwardCommand;

        public RelayCommand GoForwardCommand => _goForwardCommand ??= new RelayCommand(GoForward);

        private RelayCommand _goBackCommand;

        public RelayCommand GoBackCommand => _goBackCommand ??= new RelayCommand(GoBack);

        private void GoForward(Object data)
        {
            if (Page < PagesNumber)
            {
                PageChangingFlag = true;
                Threats = AllThreats.Skip(Page++ * ThreatsOnPage).Take(ThreatsOnPage).ToList();
                PageChangingFlag = false;
            }
        }

        private void GoBack(Object data)
        {
            if (Page > 1)
            {
                PageChangingFlag = true;
                Threats = AllThreats.Skip((--Page - 1) * ThreatsOnPage).Take(ThreatsOnPage).ToList();
                PageChangingFlag = false;
            }
        }
    }
}
