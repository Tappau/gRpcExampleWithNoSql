namespace NoSql.DataAccess
{
    internal class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Password))
                {
                    return $@"mongodb://{Host}:{Port}";
                }

                return $"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}