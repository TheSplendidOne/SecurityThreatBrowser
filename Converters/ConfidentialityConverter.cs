using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SecurityThreatBrowser
{
    public class ConfidentialityConverter : IValueConverter
    {
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            return ThreatConverter.ThreatAspectToString((ThreatAspect)value, ThreatAspect.Confidentiality);
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
