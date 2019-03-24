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
            Nullable<Int32> id = jwt.verifyJWT(token);
            System.Diagnostics.Debug.WriteLine(id);
        }
    }
}
