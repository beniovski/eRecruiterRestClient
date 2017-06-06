using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using System.Security.Cryptography;
using eRecruiterRestClient.Extensions;

namespace eRecruiterRestClient
{

    //grant_type=password&username=<userName>&password=<password>

    class Program
    {    

        static void Main(string[] args)
        {

            IAuthToken at = new AuthToken();
           
            

            Console.WriteLine(at.GetToken());

            



            Console.ReadKey();
        }                 

    }
}
