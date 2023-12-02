namespace Common.Models
{
    public class ApplicationSettingsModel
    {
        public string Jwt_SecretKey { get; set; }
        public string Jwt_Issuer { get; set; }
        public string Jwt_Audience { get; set; }
        public int ExpiresOn { get; set; }
        public string Api_key { get; set; }
        public int Otp_Time { get; set; }

    }
}
