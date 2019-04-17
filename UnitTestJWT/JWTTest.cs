using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejemplos_JWT_DotNet_CSharp;

namespace UnitTestJWT
{
    [TestClass]
    public class JWTTest
    {
        [TestMethod]
        public void CreateAndVerifyTokenTest()
        {
            Int32 IdUsuario = 250;

            JWT jwt = new JWT();
            String token = jwt.createJWT(IdUsuario);

            Assert.AreEqual(IdUsuario, jwt.verifyJWT(token));
        }
    }
}
