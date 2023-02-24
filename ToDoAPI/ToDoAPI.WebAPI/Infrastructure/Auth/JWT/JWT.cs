using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using ToDoAPI.WebAPI.Infrastructure.Models;

namespace ToDoAPI.WebAPI.Infrastructure.Auth
{
    public class JWT
    {
        
        public static string GenerateJwtToken(IConfiguration config,string Audiance, params Claim[] claims)
        {
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("JWT:SecretKey")));
            var signingCredentials = new SigningCredentials(symmetricKey,
            SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
            issuer: config.GetValue<string>("JWT:Issuer"),
            audience: Audiance,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(config.GetValue<int>("JWT:ExpiresMinutes")),
            signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool ValidateToken(string token,string Audiance, IConfiguration config)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = config.GetValue<string>("JWT:Issuer"),
                ValidateAudience = true,
                ValidAudience = Audiance,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (
                    config.GetValue<string>("JWT:SecretKey")
                )),
                ValidateIssuerSigningKey = true
            };
            SecurityToken res;
            var claimsPrincipal = new JwtSecurityTokenHandler()
                .ValidateToken(token, validationParameters, out res);
            return true;
            //ისვრის ერორს, თუ არ დავალიდურდება, რომელსაც 
            //დაჰენდლავს Global Error Handler
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

        private static UserJWT DecodeJWTBody(string token)
        {
            byte[] body = ConvertFromBase64ToBytes(token.Split(".")[1]);
            return JsonSerializer.Deserialize<UserJWT>(Encoding.UTF8.GetString(body));
        }

        public static int GetUserIDFromUserJWT(IHeaderDictionary header)
        {
            header.TryGetValue("JWTToken", out var jwt);
            int UserID = Convert.ToInt32(JWT.DecodeJWTBody(jwt.ToString()).UserID);
            return UserID;
        }

    }
}
