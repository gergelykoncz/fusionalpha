using System;

namespace DataAccess.Entities
{
    public class PatientName
    {
        public virtual string PatientId { get; set; }
        public virtual int SequenceNumber { get; set; }
        public virtual string NamePrefixCode { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string LName { get; set; }
        public virtual string ALName { get; set; }
        public virtual string SLName { get; set; }
        public virtual string FName { get; set; }
        public virtual string AFName { get; set; }
        public virtual string SFName { get; set; }
        public virtual string MName { get; set; }
        public virtual string AMName { get; set; }
        public virtual string SMName { get; set; }
        public virtual string EnteredBy { get; set; }
        public virtual DateTime EnteredDateTime { get; set; }

        protected bool Equals(PatientName other)
        {
            return string.Equals(PatientId, other.PatientId) && SequenceNumber == other.SequenceNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PatientName)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (PatientId.GetHashCode() * 397) ^ SequenceNumber;
            }
        }
    }
}
