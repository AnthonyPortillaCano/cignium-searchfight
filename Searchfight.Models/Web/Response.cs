using System;
using System.Text;

namespace Searchfight.Models.Web
{
    public class Response
    {
        public string Characters { get; set; }
        public Encoding Encoding { get; set; }
        public Uri Uri { get; set; }
    }
}
