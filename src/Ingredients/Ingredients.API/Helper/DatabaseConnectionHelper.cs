namespace src.Ingredients.Ingredients.API.Helper
{
    public static class DatabaseConnectionHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            return $"Data Source={configuration["DB_HOST"]}; Initial Catalog={configuration["DB_NAME"]}; User ID=sa; Password={configuration["DB_PASSWORD"]}; TrustServerCertificate=true;";
        }
    }
}