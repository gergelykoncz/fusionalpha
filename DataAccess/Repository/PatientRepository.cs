using DataAccess.Connection;
using DataAccess.Entities;
using DataAccess.Mappers;
using NHibernate;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly IDataConnection _dataConnection;

        public PatientRepository(IDataConnection dataConnection)
        {
            this._dataConnection = dataConnection;
        }

        public Patient Get(int id)
        {
            return this._dataConnection.Connection.QueryOver<Patient>()
                .Where(x => x.PatientId == id.ToString())
                .SingleOrDefault();
        }
        
        public IEnumerable<Patient> GetAll()
        {
            return this._dataConnection.Connection.QueryOver<Patient>()
                .Take(20)
                .List();
                
        }

        public IEnumerable<Patient> GetBy(Expression<Func<Patient, bool>> criteria)
        {
            return this._dataConnection.Connection.QueryOver<Patient>()
                .Where(criteria)
                .List();
        }

        public void Add(Patient patient)
        {
            var session = this._dataConnection.Connection;

            var transaction = session.BeginTransaction();
            session.Lock(patient, LockMode.Upgrade);

            patient.PatientNames.Add(new PatientName() { FName = "Bob" });
            session.Save(patient);
            session.Flush();

            transaction.Commit();

        }
    }
}
