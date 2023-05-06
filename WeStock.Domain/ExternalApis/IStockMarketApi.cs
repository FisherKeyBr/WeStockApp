using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeStock.Domain.ExternalApis
{
    public interface IStockMarketApi
    {
        Task<T> GetLastQuoteBy<T>(string symbol);
    }
}
