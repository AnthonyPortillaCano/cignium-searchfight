using Searchfight.Models.Web;
using Searchfight.Services.SearchEngine.Base;
using Searchfight.Utils.Extension;
using System;
using System.Threading.Tasks;

namespace Searchfight.Services.SearchEngine.Google
{
    public class Google : BaseSearchEngine, IGoogle
    {
        public Google()
        {
            request = new Request()
            {
                Title = "Google"
            };
        }

        public async Task LoadResponseBySearchValue(string searchValue)
        {
            currentResult.Text = searchValue;
            await LoadHttpResponseBySearchValue(searchValue);

        }

        public async Task LoadHttpResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(Service.Http.Google.Url.SearchEngine.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            await LoadHttpResponse(requestUri);
        }

        public void LoadResultNumber()
        {
            LoadResultNumber(Service.Http.Google.Response.ResultNumber.REGEX_PATTERN, Service.Http.Google.Response.ResultNumber.SPLIT_SEPARATOR);
        }

        public void LoadResultTime()
        {
            LoadResultTime(Service.Http.Google.Response.ResultTime.REGEX_PATTERN, Service.Http.Google.Response.ResultTime.SPLIT_SEPARATOR);
        }
    }
}
