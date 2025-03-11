using Microsoft.Build.Construction;

namespace WebAPI.JWT
{
    public class JwtToken
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExiryMinutes { get; set; }
    }
}
