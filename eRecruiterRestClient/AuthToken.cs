using eRecruiterRestClient.Extensions;
using RestSharp;
using System;

namespace eRecruiterRestClient
{
    public class AuthToken : IAuthToken
    {
        private const string clientId = "PARETTi";
        private const string pass = "qe2ewasd5t4thgf";
        private const string user = "daniel.bednarczuk@paretti.pl";
        private const string userPass = "P@retti2!";
        private string conection = $"{clientId}:{pass}".Base64Encode();
        private string token;

        public AuthToken()
        {
            var client = new RestClient("http://authorization-api.erecruiter.pl/oAuth/Token/");
            var request = new RestRequest(Method.POST);

            string body = string.Format("grant_type=password&username={0}&password={1}", user, userPass);           
            request.AddHeader("Authorization", $"Basic {conection}");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
            

            IRestResponse response = client.Execute(request);  
            
            if(response.Content==null)
                throw new ArgumentNullException(" error token can not be null");
            else
            token  = response.Content;
        }
        public string GetToken()
        {            
            return token;
        }
        
    
    }
}
