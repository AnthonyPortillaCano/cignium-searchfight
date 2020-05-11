using Searchfight.Models.Web;
using Searchfight.Services.SearchEngine.Base;
using Searchfight.Utils.Extension;
using System;
using System.Threading.Tasks;

namespace Searchfight.Services.SearchEngine.Yahoo
{
    public class Yahoo : BaseSearchEngine, IYahoo
    {
        public Yahoo() 
        {
            request = new Request()
            {
                Title = "Yahoo"
            };
        }

        public void LoadResultNumber()
        {

            LoadResultNumber(Service.Http.Yahoo.Response.ResultNumber.REGEX_PATTERN, Service.Http.Yahoo.Response.ResultNumber.SPLIT_SEPARATOR);

        }

        public async Task LoadResponseBySearchValue(string searchValue)
        {
            currentResult.Text = searchValue;
          await LoadHttpResponseBySearchValue(searchValue);
        }

        public async Task LoadHttpResponseBySearchValue(string searchValue)
        {
            var requestUri = new Uri(Service.Http.Yahoo.Url.SearchEngine.SEARCH);
            requestUri = requestUri.AddQuery("q", searchValue);

            await LoadHttpResponse(requestUri);
        }
    }
}
