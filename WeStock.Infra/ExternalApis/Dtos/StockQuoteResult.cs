using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeStock.Domain.ExternalApis.Dtos;

namespace WeStock.Infra.ExternalApis.Dtos
{
    //since this class is used only for displaying info, i'm making it simple, all props as string.
    public class StockQuoteResult : IStockInfo
    {
        [JsonPropertyName("01. symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("02. open")]
        public string Open { get; set; }

        [JsonPropertyName("03. high")]
        public string High { get; set; }

        [JsonPropertyName("04. low")]
        public string Low { get; set; }

        [JsonPropertyName("05. price")]
        public string Price { get; set; }

        [JsonPropertyName("06. volume")]
        public string Volume { get; set; }

        [JsonPropertyName("07. latest trading day")]
        public string LatestTradingDay { get; set; }

        [JsonPropertyName("08. previous close")]
        public string PreviousClose { get; set; }

        [JsonPropertyName("09. change")]
        public string Change { get; set; }

        [JsonPropertyName("10. change percent")]
        public string ChangePercent { get; set; }
    }

    public class StockQuoteRoot 
    {
        [JsonPropertyName("Global Quote")]
        public StockQuoteResult GlobalQuote { get; set; }
    }
}
