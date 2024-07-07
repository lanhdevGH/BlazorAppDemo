using Microsoft.Data.SqlClient;

namespace TodoList.Api.Configurations
{
    public class ConnectionDB
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Encrypt { get; set; }
        public string TrustServerCertificate { get; set; }

        public string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = Server,
                InitialCatalog = Database,
                UserID = User,
                Password = Password,
                Encrypt = Encrypt == "true",
                TrustServerCertificate = TrustServerCertificate == "true"
            };

            //if (AuthenticationType == "SQL")
            //{
            //    builder.UserID = User;
            //    builder.Password = Password;
            //}
            //else
            //{
            //    builder.IntegratedSecurity = true;
            //}

            return builder.ConnectionString;
        }
    }
}
