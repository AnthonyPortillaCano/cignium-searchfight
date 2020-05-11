using System;

namespace Searchfight.Utils.Helper
{
    public class ErrorHelper
    {
        private static string GetTypeHeader(Type type)
        {
            return $"{(type != null ? $"[{type.Name}]" : "")}";
        }

        public static string GetRegexGroupEmptyError(Type type = null)
        {
            return $"{GetTypeHeader(type)} {ConstantHelpers.Error.REGEX_GROUP_EMPTY}";
        }
    }
}
