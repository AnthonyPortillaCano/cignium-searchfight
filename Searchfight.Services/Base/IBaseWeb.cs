using Searchfight.Models.Web;
using System.Net;
using System.Threading.Tasks;

namespace Searchfight.Services.Base
{
    interface IBaseWeb
    {
        Request GetRequest();
        Response GetResponse();
        Task LoadResponse(HttpWebRequest httpWebRequest);
    }
}
