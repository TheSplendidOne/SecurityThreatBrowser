using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SecurityThreatBrowser
{
    public static class ThreatConverter
    {
        public const String TrueWord = "Да";

        public const String FalseWord = "Нет";

        public static String ThreatAspectToString(ThreatAspect mixedAspect, ThreatAspect verificationAspect)
        {
            return mixedAspect.HasFlag(verificationAspect) ? TrueWord : FalseWord;
        }

        public static ThreatAspect StringFlagToThreatAspect(String value, ThreatAspect verificationAspect)
        {
            return value == "1" ? verificationAspect : ThreatAspect.None;
        }
    }
}
