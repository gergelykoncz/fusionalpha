using System;
using System.Data.Common;

namespace DataAccess.Connection
{
    public interface IDataConnection : IDisposable
    {
        DbConnection Connection { get; }
    }
}
