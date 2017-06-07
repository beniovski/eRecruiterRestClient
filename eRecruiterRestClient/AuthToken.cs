using eRecruiterRestClient.Deserialize;
using eRecruiterRestClient.Extensions;
using eRecruiterRestClient.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace eRecruiterRestClient
{
    public class AuthToken : IAuthToken
    {
        private const string clientId = "";
        private const string pass = "";
        private const string user = "";
        private const string userPass = "";

        private string authString = $"Basic "+ $"{clientId}:{pass}".Base64Encode();
        private string token;
        

        public AuthToken()
        {
            var client = new RestClient("http://authorization-api.erecruiter.pl/oAuth/Token/");
            var request = new RestRequest(Method.POST);
            string body = string.Format("grant_type=password&username={0}&password={1}", user, userPass);     
            
            request.AddHeader("Authorization",authString);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", body, ParameterType.RequestBody);
                       
            var response = Response(client, request);

            if (response.Content==null)
                throw new ArgumentNullException("error token can not be null");                      
            else
            {
                TokenDeserialize td = JsonConvert.DeserializeObject<TokenDeserialize>(response.Content);
                token = td.access_token;
            }
            
        }
        
        private IRestResponse Response(RestClient client, RestRequest request )
        {
            IRestResponse response = client.Execute(request);
            return response;
        }
        
        public string GetToken()
        {            
            return token;
        }
        
    
    }
}
