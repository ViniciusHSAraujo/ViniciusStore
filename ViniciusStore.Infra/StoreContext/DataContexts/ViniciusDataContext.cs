using System;
using System.Data;
using System.Data.SqlClient;
using ViniciusStore.Shared;


namespace ViniciusStore.Infra.StoreContext.DataContexts {
    public class ViniciusDataContext : IDisposable {

        public SqlConnection Connection { get; set; }

        public ViniciusDataContext() {
            Connection = new SqlConnection(Settings.ConnectionString);
        }
        
        public void Dispose() {
            if (Connection.State != ConnectionState.Closed) {
                Connection.Close();
            }
        }
    }
}