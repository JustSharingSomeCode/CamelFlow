namespace CamelFlow_Backend.Data
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = string.Empty;

        public string Secret { get; set; } = string.Empty;

        public int ExpirationInDays { get; set; }
    }
}
