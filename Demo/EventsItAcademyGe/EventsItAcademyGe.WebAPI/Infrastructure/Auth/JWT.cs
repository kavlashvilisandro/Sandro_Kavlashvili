using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Auth
{
    public static class JWT
    {
        public static int GetUserIDFromJWT(string jwt)
        {
            string bodyBase64 = jwt.Split(" ")[1].Split(".")[1];
            JWTBody body = JsonSerializer.Deserialize<JWTBody>(Base64ToString(bodyBase64));
            return Convert.ToInt32(body.UserID);
        }
        public static string GenerateJwtToken(IConfiguration config, params Claim[] _claims)
        {
            SymmetricSecurityKey symmetricKey = 
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("JWT:SecretKey")));
            
            SigningCredentials signingCredentials = 
                new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            
            JwtSecurityToken token = new JwtSecurityToken
                (
                    issuer: config.GetValue<string>("JWT:Issuer"),
                    audience: config.GetValue<string>("JWT:Audience"),
                    claims: _claims,
                    expires: DateTime.Now.AddMinutes(config.GetValue<int>("JWT:Expires")),
                    signingCredentials: signingCredentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string Base64ToString(string input)
        {
            byte[] bytes = ConvertFromBase64ToBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }
        public static byte[] ConvertFromBase64ToBytes(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) return null;
            try
            {
                string working = input.Replace('-', '+').Replace('_', '/'); ;
                while (working.Length % 4 != 0)
                {
                    working += '=';
                }
                return Convert.FromBase64String(working);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static string StringToBase64(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}
