namespace Integration.SM.API.Endpoints.Models
{
    public class AppSettings
    {
         public const string Config = "Config";
        public string SecretKey { get; set; } = string.Empty;
        public int Expiration { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}