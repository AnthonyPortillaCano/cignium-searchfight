namespace Searchfight.Services
{
    public class Service
    {
        public static class WebRequest
        {
            public const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";


            public const int TIMEOUT = 10000;

            public static class Api
            {
                public const string CONTENT_TYPE = "application/json";
            }

            public static class Default
            {
                public const string CONTENT_TYPE = "application/x-www-form-urlencoded";
            }
        }

        public static class Http
        {
            public static class Bing
            {
                public static class Response
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<span)(?:[^>]*)(?:class=\""sb_count\"")(?:[^>]*)(?:>)(.*?)(?:</span>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class SearchEngine
                    {
                        public const string SEARCH = "https://www.bing.com/search";
                    }
                }
            }

            public static class Google
            {
                public static class Response
                {
                    public static class ResultNumber
                    {

                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:id=\""resultStats\"")(?:[^>]*)(?:>)(.*?)(?:<nobr>)";

                        public const string SPLIT_SEPARATOR = " ";
                    }

                    public static class ResultTime
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:id=\""resultStats\"")(?:[^>]*)(?:>)(?:.*)(?:<nobr>)(.*?)(?:</nobr>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class SearchEngine
                    {
                        public const string SEARCH = "https://www.google.com/search";
                    }
                }
            }

            public static class Yahoo
            {
                public static class Response
                {
                    public static class ResultNumber
                    {
                        public const string REGEX_PATTERN = @"(?:<div)(?:[^>]*)(?:class=\""compPagination\"")(?:.*?)(?:<span)(?:[^>]*)(?:>)(.*?)(?:</span>)";
                        public const string SPLIT_SEPARATOR = " ";
                    }
                }

                public static class Url
                {
                    public static class SearchEngine
                    {
                        public const string SEARCH = "https://search.yahoo.com/search";
                    }
                }
            }
        }
    }
}
