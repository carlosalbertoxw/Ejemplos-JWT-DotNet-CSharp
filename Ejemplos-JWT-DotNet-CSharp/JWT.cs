using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Ejemplos_JWT_DotNet_CSharp
{
    public class JWT
    {
        private static String key = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";

        public String createJWT(Int32 IdUser)
        {
            var timeUnix = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            var header = new JwtHeader(new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha512));
            var payload = new JwtPayload();
            payload.Add("id", IdUser);
            //La validación de la expiración tiene 5 minutos mas de tiempo por eso al tiempo de expiración 
            //se le restan 4 para que solo quede con un minuto de tiempo de vida
            payload.Add("exp", (Convert.ToUInt64(timeUnix) - (60 * 4)));
            payload.Add("iat", (Convert.ToUInt64(timeUnix) - (60 * 5)));
            payload.Add("nbf", (Convert.ToUInt64(timeUnix) - (60 * 5)));

            JwtSecurityToken jst = new JwtSecurityToken(header,payload);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jst);
        }

        public Nullable<Int32> verifyJWT(String token)
        {
            try
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var readableToken = jwtHandler.CanReadToken(token);
                if (readableToken == true)
                {
                    var validationParameters = new TokenValidationParameters()
                    {
                        RequireExpirationTime = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };

                    SecurityToken securityToken;
                    var principal = jwtHandler.ValidateToken(token, validationParameters, out securityToken);

                    var tk = jwtHandler.ReadJwtToken(token);
                    var claims = tk.Claims;
                    foreach (Claim c in principal.Claims)
                    {
                        if (c.Type=="id")
                        {
                            return Convert.ToInt32(c.Value);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("M:"+e.StackTrace);
            }
            return null;
        }
    }
}