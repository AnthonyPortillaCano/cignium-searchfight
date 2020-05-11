namespace Searchfight.Utils.Helper
{
    public class ConstantHelpers
    {
        public static class General
        {
            public const int PREFERRED_OPERATION = Operation.HTTP;
        }

        public static class Error
        {
            public const string REGEX_GROUP_EMPTY = "Regex group is empty";
        }

        public static class Operation
        {
            public const int API = 1;
            public const int HTTP = 2;
        }
    }
}
