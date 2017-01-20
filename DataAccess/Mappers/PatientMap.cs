using DataAccess.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DataAccess.Mappers
{
    public class PatientMap : ClassMapping<Patient>
    {
        public PatientMap()
        {
            Table("PATIENT");
            Id(m => m.PatientId, c => c.Column("PATIENT_ID"));
            
            Property(m => m.BirthDate, c => c.Column("BIRTH_DATE"));
            Property(m => m.SSN, c => c.Column("SSN"));
            Property(m => m.NumberOfPregnancies, c => c.Column("NUMBER_OF_PREGNANCIES"));
            Property(m => m.MergedToPID, c => c.Column("MERGED_TO_PID"));
            Property(m => m.EnterpriseId, c => c.Column("ENTERPRISE_ID"));
            Property(m => m.StatusDateTime, c => c.Column("STATUS_DATETIME"));
            Property(m => m.CenterCode, m => m.Column("CENTER_CD"));
            Property(m => m.ConvertedPatient, c => c.Column("CONVERTED_PATIENT"));
            Property(m => m.CountConvertedAbo, c => c.Column("COUNT_CONVERTED_ABO"));

            Set(m => m.PatientNames,
                m =>
                {
                    m.Fetch(CollectionFetchMode.Select);
                    m.Lazy(CollectionLazy.NoLazy);
                    m.Inverse(false);
                    m.OrderBy("SEQNO");
                    m.Key(key => key.Column("PATIENT_ID"));
                },
                m => m.OneToMany());
        }
    }
}
