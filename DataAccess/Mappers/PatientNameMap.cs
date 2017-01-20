using DataAccess.Entities;
using NHibernate.Mapping.ByCode.Conformist;

namespace DataAccess.Mappers
{
    public class PatientNameMap : ClassMapping<PatientName>
    {
        public PatientNameMap()
        {
            Table("PATIENT_NAME");
            ComposedId(m =>
            {
                m.Property(x => x.PatientId, x =>
                {
                    x.Column("PATIENT_ID");
                    x.Type(NHibernate.NHibernateUtil.String);
                });
                m.Property(x => x.SequenceNumber, x =>
                {
                    x.Column("SEQNO");
                    x.Type(NHibernate.NHibernateUtil.Int32);
                });
            });
            Property(m => m.NamePrefixCode, m => m.Column("NAME_PREFIX_CD"));
            Property(m => m.Suffix);
            Property(m => m.LName, m => m.Column("LNAME"));
            Property(m => m.ALName, m => m.Column("ALNAME"));
            Property(m => m.SLName, m => m.Column("SLNAME"));
            Property(m => m.FName, m => m.Column("FNAME"));
            Property(m => m.AFName, m => m.Column("AFNAME"));
            Property(m => m.SFName, m => m.Column("SFNAME"));
            Property(m => m.MName, m => m.Column("MNAME"));
            Property(m => m.AMName, m => m.Column("AMNAME"));
            Property(m => m.SMName, m => m.Column("SMNAME"));
            Property(m => m.EnteredBy, m => m.Column("ENTERED_BY"));
            Property(m => m.EnteredDateTime, m => m.Column("ENTERED_DATETIME"));
        }
    }
}
