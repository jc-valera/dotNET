namespace Auth.Core.Common.Entities
{
    public class AuthResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        public string Token { get; set; }
    }
}
