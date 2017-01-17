using DataAccess.Entities;
using System.Data.Common;

namespace DataAccess.Mappers
{
    public interface ISqlPatientMapper
    {
        Patient Map(DbDataReader reader);
    }
}
