using System;

namespace Ejemplos_JWT_DotNet_CSharp
{
    class Program
    {
        /**
         * Ejecutar PM> Install-Package System.IdentityModel.Tokens.Jwt -Version 5.4.0
         * */
        static void Main(string[] args)
        {
            JWT jwt = new JWT();
            String token = jwt.createJWT(100);
            System.Diagnostics.Debug.WriteLine(token);
            Nullable<Int32> id = jwt.verifyJWT("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTAwLCJleHAiOjE1NTQ0OTYyNTR9.H7DIEDok2n2LRpFPv6k-5EKAxsM2EETUU6BL1e9naR_VIEfVPQoMEloVWkat4RNLxRJd6zxzaBV7wV74h2QlBg");
            System.Diagnostics.Debug.WriteLine(id);
        }
    }
}
