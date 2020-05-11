using Searchfight.Models.SearchEngine;
using Searchfight.Services.Base;
using Searchfight.Utils.Extension;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Searchfight.Services.SearchEngine.Base
{
    public abstract class BaseSearchEngine : BaseWeb, IBaseSearchEngine
    {
        protected Result currentResult;
        protected Result topResult;

        public BaseSearchEngine()
        {
            currentResult = new Result();
            topResult = new Result();

        }

        public Result GetCurrentResult()
        {
            return currentResult;
        }

        public Result GetTopResult()
        {
            return topResult;
        }

        public void LoadResultNumber(string regexPattern, string splitSeparator = " ")
        {
            var responseCharacters = response.Characters.ToString();

            responseCharacters.TryToLong(out long resultNumber, regexPattern, splitSeparator);

            currentResult.Number = resultNumber;

            if (resultNumber > topResult.Number)
            {
                topResult = currentResult;
            }

        }

        public void LoadResultTime(string regexPattern, string splitSeparator = " ")
        {
            var responseCharacters = response.Characters.ToString();

            responseCharacters.TryToSeconds(out TimeSpan resultTime, regexPattern, splitSeparator);

            currentResult.Time = resultTime;
        }

        public async Task LoadHttpResponse(Uri uri)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.ContentType = Service.WebRequest.Default.CONTENT_TYPE;
            httpWebRequest.UserAgent = Service.WebRequest.USER_AGENT;
            httpWebRequest.Timeout = Service.WebRequest.TIMEOUT;

            await LoadResponse(httpWebRequest);
        }
    }
}
