
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Searchfight.Tests
{
    [TestClass]
    public class SearchfightEngine
    {
        [TestMethod]
        public async Task Query_Expected_PositiveAsync()
        {
            string[] searchValues = new string[3];
            Principal principal = new Principal();
            var result = await principal.CalculateSearchfight(searchValues);
            Assert.IsNotNull(result);
        }
    }
}
