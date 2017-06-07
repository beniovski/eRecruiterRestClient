using eRecruiterRestClient.Deserialize;
using eRecruiterRestClient.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace eRecruiterRestClient
{
    class ErecruiterAction : IErecruiterAction
    {
        private readonly IAuthToken _authToken;
        private readonly IRestResponse _response;
        private readonly RestClient _restClient;
        private readonly RestRequest _restRequest;
        private readonly int companyId;
       
        private static string url = "https://api.erecruiter.pl";       


        public ErecruiterAction(IAuthToken authToken)
        {
            _restRequest = new RestRequest();
            _restClient = new RestClient(url);
            _authToken = authToken;
            companyId = GetCompanyId();            
        }

        public CompanyDeserialize GetCompanyInfo()
        {
            var responseValue = ResponseValue("/v1.0/Account/Companies", Method.GET); 
            CompanyDeserialize cd = JsonConvert.DeserializeObject<CompanyDeserialize>(responseValue);
            return cd;
        }

        public string GetAllCandidate()
        {
           return ResponseValue("/v1.0/Candidates", Method.GET);
        }


          
        private string ResponseValue(String resouce, Method method)
        {
            _restRequest.Resource = resouce;
            _restRequest.Method = method;
            _restRequest.AddParameter("companyId", companyId);
            _restRequest.AddHeader("Authorization", AuthHeader());
            IRestResponse response = _restClient.Execute(_restRequest);
            var content = response.Content;
            return content;
        }

        private int GetCompanyId()
        {
            CompanyDeserialize cd = new CompanyDeserialize();
            return cd.companyId;
        }

        private string AuthHeader()
        {
            return "Bearer " + _authToken.GetToken();
        }

    }
}
