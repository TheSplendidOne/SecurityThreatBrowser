using System;

namespace SecurityThreatBrowser
{
    public class Threat : IEquatable<Threat>
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String Source { get; set; }

        public String Target { get; set; }

        public ThreatAspect Aspect { get; set; }

        public DateTime AdditionDate { get; set; }

        public DateTime ChangeDate { get; set; }

        public override Int32 GetHashCode()
        {
            return Id;
        }

        public override Boolean Equals(Object obj)
        {
            return Equals(obj as Threat);
        }

        public Boolean Equals(Threat anotherThreat)
        {
            return anotherThreat != null &&
                   anotherThreat.Id == Id &&
                   anotherThreat.Name == Name &&
                   anotherThreat.Description == Description &&
                   anotherThreat.Source == Source &&
                   anotherThreat.Target == Target &&
                   anotherThreat.Aspect == Aspect &&
                   anotherThreat.AdditionDate.Equals(AdditionDate) &&
                   anotherThreat.ChangeDate.Equals(ChangeDate);
        }
    }
}
