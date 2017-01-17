using DataAccess.Connection;
using DataAccess.Entities;
using DataAccess.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataAccess.Repository
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly IDataConnection _dataConnection;
        private readonly ISqlPatientMapper _patientMapper;

        public PatientRepository(IDataConnection dataConnection,
            ISqlPatientMapper patientMapper)
        {
            this._dataConnection = dataConnection;
            this._patientMapper = patientMapper;
        }

        public Patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            var result = new List<Patient>();
            var command = this._dataConnection.Connection.CreateCommand();
            command.CommandText = "SELECT * FROM Patient WHERE RowNum < 20";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var patient = this._patientMapper.Map(reader);
                result.Add(patient);

            }
            return result.AsEnumerable();
        }

        public IEnumerable<Patient> GetBy(Func<Patient, bool> criteria)
        {
            throw new NotImplementedException();
        }
    }
}
