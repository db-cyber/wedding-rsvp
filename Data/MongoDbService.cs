using MongoDB.Driver;

namespace WeddingRSVP.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly string? connectionString;
        private readonly MongoUrl mongoUrl;

        public IMongoDatabase Database { get; }

        public MongoDbService(IConfiguration configuration) 
        { 
            _configuration = configuration;

            connectionString = _configuration.GetConnectionString("DbConnection");

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.SslSettings = new SslSettings
            {
                EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
            };

            var client = new MongoClient(settings);

            mongoUrl = MongoUrl.Create(connectionString);

            Database = client.GetDatabase(mongoUrl.DatabaseName);
        }
    }
}
