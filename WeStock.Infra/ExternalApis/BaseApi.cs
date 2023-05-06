using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Infra.ExternalApis
{
    public abstract class BaseApi
    {
        protected abstract string BaseUri { get; }

        protected async Task<T> Get<T>(string endpoint)
        {
            var options = new RestClientOptions(BaseUri);

            var client = new RestClient(options);
            var request = new RestRequest(endpoint);
            
            var response = await client.GetAsync<T>(request);
            return response!;
        }
    }
}
