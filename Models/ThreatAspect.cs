using System;

namespace SecurityThreatBrowser
{
    [Flags]
    public enum ThreatAspect
    {
        None = 0,
        Confidentiality = 1,
        Integrity = 2,
        Availability = 4
    }
}
