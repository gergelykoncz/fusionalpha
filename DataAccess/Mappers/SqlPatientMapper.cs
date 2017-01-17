using DataAccess.Entities;
using System;
using System.Data.Common;

namespace DataAccess.Mappers
{
    public class SqlPatientMapper : ISqlPatientMapper
    {
        private int parseStringToInt(string rawValue)
        {
            int result = 0;
            int.TryParse(rawValue, out result);
            return result;
        }

        private DateTime? parseDbDateTime(DbDataReader reader, string columnName)
        {
            int pos = reader.GetOrdinal(columnName);
            if (reader.IsDBNull(pos))
            {
                return null;
            }
            else
            {
                return reader.GetDateTime(pos);
            }
        }

        private bool hasColumn(DbDataReader reader, string columName)
        {
            try
            {
                reader.GetOrdinal(columName);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Patient Map(DbDataReader reader)
        {
            var patient = new Patient();
            patient.ID = parseStringToInt(reader["Patient_ID"].ToString());
            patient.SSN = parseStringToInt(reader["SSN"].ToString());
            patient.BirthDate = parseDbDateTime(reader, "birth_date");
            if (hasColumn(reader, "fname") && hasColumn(reader, "lname"))
            {
                patient.Name = string.Format("{0} {1}", reader["fname"], reader["lname"]);
            }

            string gender = reader["gender_cd"].ToString();
            if (gender == null)
            {
                patient.Gender = Gender.Unknown;
            }
            else if (gender.Equals("m", StringComparison.InvariantCultureIgnoreCase))
            {
                patient.Gender = Gender.Male;
            }
            else if (gender.Equals("f", StringComparison.InvariantCultureIgnoreCase))
            {
                patient.Gender = Gender.Female;
            }

            return patient;
        }
    }
}
