namespace AuthJWTCookie.Services.UserAPI.Cryptography
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiresHoures { get; set; }
    }
}