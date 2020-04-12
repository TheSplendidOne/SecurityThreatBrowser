using System.CodeDom;

namespace SecurityThreatBrowser
{
    public class UpdateThreatInfo
    {
        public Threat OldThreat { get; set; }

        public Threat NewThreat { get; set; }

        public UpdateThreatInfo(Threat oldThreat, Threat newThreat)
        {
            OldThreat = oldThreat;
            NewThreat = newThreat;
        }
    }
}
