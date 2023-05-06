using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.ExternalApis;

namespace WeStock.Infra.ExternalApis
{
    public class AlphaVantageApi : BaseApi, IStockMarketApi
    {
        public const string API_KEY = "OX8G9FHQUOOZDUNC";

        protected override string BaseUri { get => "https://www.alphavantage.co/"; }

        public async Task<T> GetLastQuoteBy<T>(string symbol)
        {
            var endpoint = $"query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={API_KEY}";
            return await Get<T>(endpoint);
        }
    }
}
