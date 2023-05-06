using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain.ExternalApis.Dtos;

namespace WeStock.Domain.ExternalApis
{
    public interface IStockMarketApi
    {
        Task<IStockInfo> GetLastQuoteBy(string symbol);
    }
}
