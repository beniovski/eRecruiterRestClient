using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;  
using eRecruiterRestClient;

namespace eRecruiterRestClient.Tests
{
    [TestClass]
    public class AuthTokenTests
    {
        private AuthToken at;

        public AuthTokenTests()
        {
            at = new AuthToken();
        }

        [TestMethod]
        public void check_returned_token_is_not_empty()
        {
            Assert.IsNotNull(at.GetToken());
        }

        [TestMethod]
        public void check_token_request_return_code_200()
        {
            
        }
    }
}
