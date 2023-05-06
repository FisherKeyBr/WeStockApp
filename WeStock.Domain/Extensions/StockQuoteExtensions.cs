using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeStock.Domain.Enums;
using WeStock.Domain.ExternalApis.Dtos;

namespace WeStock.Domain.Extensions
{
    public static class StockQuoteExtensions
    {
        private static Regex _regexCommandBeforeSpace = new Regex(@"(^\S+)");

        //keeping it simple with no date formatting or nothing like that.
        public static string GetFormattedMessage(this IStockInfo stockInfo)
        {
            if(stockInfo is null || string.IsNullOrEmpty(stockInfo.Symbol?.Trim()))
            {
                return "No stock quotes found for this symbol";
            }

            return $@"
                Symbol              : {stockInfo.Symbol}
                Open                : {stockInfo.Open}
                High                : {stockInfo.High}
                Low                 : {stockInfo.Low}
                Price               : {stockInfo.Price}
                Volume              : {stockInfo.Volume}
                Latest Trading Day  : {stockInfo.LatestTradingDay}
                Change              : {stockInfo.Change}
                Change Percent      : {stockInfo.ChangePercent}
            ";  
        }

        public static string ExtractSymbol(this CommandTypeEnum enumm, string message)
        {
            var match = _regexCommandBeforeSpace.Match(message);
            return match.Success
                ? match.Value.Replace(enumm.GetDescription(), string.Empty)
                : string.Empty;
        }
    }
}
