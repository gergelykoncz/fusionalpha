using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Entities
{
    public class Patient
    {
        public Patient()
        {
            PatientNames = new HashSet<PatientName>();
        }

        public virtual string PatientId { get; set; }

       
        public virtual Gender Gender { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual string SSN { get; set; }
        public virtual int? NumberOfPregnancies { get; set; }
        public virtual string MergedToPID { get; set; }
        public virtual string EnterpriseId { get; set; }
        public virtual DateTime StatusDateTime { get; set; }
        public virtual string ConvertedPatient { get; set; }
        public virtual string CountConvertedAbo { get; set; }
        public virtual ISet<PatientName> PatientNames { get; protected set; }

        [Obsolete("In requirements discussions, this appears to be a value that is set but not updated and should not be used for business logic. Notably, a patient can simultaneously belong to multiple centers, the visit is the correct relationship to link to center cd. Leaving field in place for compatibility with legacy datamodel.")]
        public virtual string CenterCode { get; set; }
    }
}
