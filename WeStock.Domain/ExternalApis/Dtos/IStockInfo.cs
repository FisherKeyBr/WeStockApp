using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Domain.ExternalApis.Dtos
{
    public interface IStockInfo
    {
        string Symbol { get; set; }
        string Open { get; set; }
        string High { get; set; }
        string Low { get; set; }
        string Price { get; set; }
        string Volume { get; set; }
        string LatestTradingDay { get; set; }
        string PreviousClose { get; set; }
        string Change { get; set; }
        string ChangePercent { get; set; }
    }
}
