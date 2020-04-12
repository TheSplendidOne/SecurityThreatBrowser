using System.Collections.Generic;
using System.Linq;

namespace SecurityThreatBrowser
{
    public class UpdateReport
    {
        public List<Threat> AddedThreats { get; }

        public List<Threat> RemovedThreats { get; }

        public List<UpdateThreatInfo> UpdateThreatInfos { get; }

        private UpdateReport(List<Threat> addedThreats, List<Threat> removedThreats, List<UpdateThreatInfo> updateThreatInfos)
        {
            AddedThreats = addedThreats;
            RemovedThreats = removedThreats;
            UpdateThreatInfos = updateThreatInfos;
        }

        public static UpdateReport CreateUpdateReport(List<Threat> oldThreats, List<Threat> newThreats)
        {
            var oldThreatsId = oldThreats.Select(threat => threat.Id).ToList();
            var newThreatsId = newThreats.Select(threat => threat.Id).ToList();
            var added = newThreatsId
                .Except(oldThreatsId)
                .Select(threatId => newThreats.SkipWhile(threat => threat.Id != threatId).Take(1).Single())
                .ToList();
            var removed = oldThreatsId
                .Except(newThreatsId)
                .Select(threatId => oldThreats.SkipWhile(threat => threat.Id != threatId).Take(1).Single())
                .ToList();
            var updated = oldThreats
                .Concat(newThreats)
                .GroupBy(threat => threat.Id)
                .Where(group => !group.First().Equals(group.Last()))
                .Select(group => group.OrderBy(threat => threat.ChangeDate))
                .Select(orderedGroup => new UpdateThreatInfo(orderedGroup.First(), orderedGroup.Last()))
                .ToList();
            return new UpdateReport(added, removed, updated);
        }
    }
}
