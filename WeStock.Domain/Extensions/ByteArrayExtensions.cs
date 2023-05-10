using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeStock.Domain.Extensions
{
    public static class ByteArrayExtensions
    {
        public static T ToObject<T>(this byte[] byteArray) where T: class, new()
        {
            using MemoryStream ms = new MemoryStream(byteArray);
            T ex = JsonSerializer.Deserialize<T>(ms);
            return ex;
        }
    }
}
