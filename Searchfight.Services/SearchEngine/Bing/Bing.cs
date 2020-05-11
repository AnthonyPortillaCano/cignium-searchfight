using Searchfight.Models.Web;
using Searchfight.Services.SearchEngine.Base;
using Searchfight.Utils.Extension;
using System;
using System.Threading.Tasks;

namespace Searchfight.Services.SearchEngine.Bing
{
    public class Bing : BaseSearchEngine, IBing
    {
        public Bing()
        {
            request = new Request()
            {
                Title = "Bing"
            };
        }

        public void LoadResultNumber()
        {
            LoadResultNumber(Service.Http.Bing.Response.ResultNumber.REGEX_PATTERN, Service.Http.Bing.Response.ResultNumber.SPLIT_SEPARATOR);
        }

        public async Task LoadResponseBySearchValue(string searchValue)
        {
            currentResult.Text = searchValue;
            await LoadHttpResponseBySearchValue(searchValue);
        }
        public async Task LoadHttpResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(Service.Http.Bing.Url.SearchEngine.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            await LoadHttpResponse(requestUri);
        }
    }
}
