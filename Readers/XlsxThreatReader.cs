using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using ExcelDataReader;

namespace SecurityThreatBrowser
{
    public static class XlsxThreatReader
    {
        public const String DefaultExtension = ".xlsx";

        public static Boolean ReadThreats(String filePath, out IEnumerable<Threat> threats)
        {
            try
            {
                using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                using var reader = ExcelReaderFactory.CreateReader(stream);
                threats = reader
                    .AsDataSet()
                    .Tables[0]
                    .Rows
                    .Cast<DataRow>()
                    .Skip(2)
                    .Select(row => ParseRow(row.ItemArray.Select(item => item.ToString()).ToArray()));
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Не удалось прочитать файл");
                threats = null;
                return false;
            }

        }

        private static Threat ParseRow(String[] rowItems)
        {
            return new Threat
            {
                Id = Int32.Parse(rowItems[0]),
                Name = rowItems[1],
                Description = rowItems[2],
                Source = rowItems[3],
                Target = rowItems[4],
                Aspect = ThreatConverter.StringFlagToThreatAspect(rowItems[5], ThreatAspect.Confidentiality) |
                         ThreatConverter.StringFlagToThreatAspect(rowItems[6], ThreatAspect.Integrity) |
                         ThreatConverter.StringFlagToThreatAspect(rowItems[7], ThreatAspect.Availability),
                AdditionDate = DateTime.ParseExact(rowItems[8], "dd.MM.yyyy h:mm:ss", CultureInfo.CurrentCulture),
                ChangeDate = DateTime.ParseExact(rowItems[9], "dd.MM.yyyy h:mm:ss", CultureInfo.CurrentCulture)
            };
        }
    }
}
