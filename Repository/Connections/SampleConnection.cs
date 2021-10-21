using Repository.Connections.Interfaces;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Repository.Connections
{
    public class SampleConnection : DbConnection, ISampleConnection
    {
        protected IDbConnection DapperConnection { get; set; }
        public SampleConnection(string stringConnection)
        {
            DapperConnection = new SqlConnection(stringConnection);
        }
        public override string ConnectionString { get { return DapperConnection.ConnectionString; } set { DapperConnection.ConnectionString = value; } }

        public override string Database { get { return DapperConnection.Database; } }

        public override string DataSource { get; }

        public override string ServerVersion { get; }

        public override ConnectionState State => DapperConnection.State;

        public override void ChangeDatabase(string databaseName)
        {
            DapperConnection.ChangeDatabase(databaseName);
        }

        public override void Close()
        {
            DapperConnection.Close();
        }

        public override void Open()
        {
            DapperConnection.Open();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return (DbTransaction)DapperConnection.BeginTransaction();
        }

        protected override DbCommand CreateDbCommand()
        {
            return (DbCommand)DapperConnection.CreateCommand();
        }
    }
}
