using System.ComponentModel;
using System.Text.RegularExpressions;
using WeStock.Domain.Extensions;

namespace WeStock.Domain.Enums
{
    public enum CommandTypeEnum
    {
        NONE = 0,

        [Description("/stock=")]
        FETCH_STOCK_QUOTE = 1
    }

    public class CommandTypeHelper
    {
        public static bool IsCommand(string message)
        {
            var enumms = Enum.GetValues(typeof(CommandTypeEnum))
                .Cast<CommandTypeEnum>();

            var found = GetBy(message);

            return found != CommandTypeEnum.NONE;
        }

        public static CommandTypeEnum GetBy(string message)
        {
            var enumms = Enum.GetValues(typeof(CommandTypeEnum))
               .Cast<CommandTypeEnum>();

            return enumms.FirstOrDefault(en => message.StartsWith(en.GetDescription()));
        }
    }
}
