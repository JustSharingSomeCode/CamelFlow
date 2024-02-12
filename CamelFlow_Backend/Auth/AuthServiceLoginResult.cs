namespace CamelFlow_Backend.Auth
{
    public class AuthServiceLoginResult
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
