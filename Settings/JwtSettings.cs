namespace SimpleSocialBoardServer.Settings
{
    public static class JwtSettings
    {
        public static string Key => Environment.GetEnvironmentVariable("Jwt_Key")!;
        public static string Issuer => Environment.GetEnvironmentVariable("Jwt_Issuer")!;
        public static string Audience => Environment.GetEnvironmentVariable("Jwt_Audience")!;
        public static int Jwt_Expire => int.TryParse(Environment.GetEnvironmentVariable("Jwt_Expire"), out var expire) ? expire : 60; //預設60分鐘
    }
}