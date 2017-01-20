using NHibernate;
using System;

namespace DataAccess.Connection
{
    public interface IDataConnection : IDisposable
    {
        ISession Connection { get; }
    }
}
