using Searchfight.Models.SearchEngine;
using Searchfight.Services.SearchEngine.Base;
using Searchfight.Services.SearchEngine.Bing;
using Searchfight.Services.SearchEngine.Google;
using Searchfight.Services.SearchEngine.Yahoo;
using Searchfight.Utils.Helper;
using System;
using System.Threading.Tasks;

namespace Searchfight.Tests
{
    public class Principal
    {
        public async Task<string> CalculateSearchfight(string[] searchValues)
        {
            try
            {
                if (GeneralHelpers.IsDebug())
                {
                    searchValues = new string[]
                    {
                        ".net",
                        "java",
                        "java script"
                    };
                }

                if (searchValues.Length <= 0)
                {
                    Console.Write("\r\nUsage: Cignium.Searchfight.exe search_queries\r\n");
                    return "";
                }

                // Search Engines
                var bing = new Bing();
                var google = new Google();
                var yahoo = new Yahoo();

                var baseSearchEngines = new BaseSearchEngine[]
                {
                    bing,
                    google,
                    yahoo
                };

                Result totalTopResult = await GetWinnerSearch(searchValues, bing, google, yahoo, baseSearchEngines);


                return $"winner: {totalTopResult.Text}";
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;

                Console.WriteLine($"\r\n{e.InnerException?.StackTrace ?? e.StackTrace}\r\n{e.Message}");
                Console.ResetColor();
                return "";
            }
            finally
            {
                Console.WriteLine("\r\nPress any key to continue...");

            }
        }

        private static async Task<Result> GetWinnerSearch(string[] searchValues, Bing bing, Google google, Yahoo yahoo, BaseSearchEngine[] baseSearchEngines)
        {
            for (var i = 0; i < searchValues.Length; i++)
            {
                var searchValue = searchValues[i];

                Console.Write($"{searchValue}:");

                await bing.LoadResponseBySearchValue(searchValue);
                await google.LoadResponseBySearchValue(searchValue);
                await yahoo.LoadResponseBySearchValue(searchValue);

                // Bing
                bing.LoadResultNumber();

                // Google
                google.LoadResultNumber();
                google.LoadResultTime();

                // Yahoo
                yahoo.LoadResultNumber();

                for (var j = 0; j < baseSearchEngines.Length; j++)
                {
                    var baseSearchEngine = baseSearchEngines[j];
                    var currentResult = baseSearchEngine.GetCurrentResult();
                    var request = baseSearchEngine.GetRequest();

                    Console.Write($" {request.Title}: {currentResult.Number} ({currentResult.Time.TotalSeconds}s)");
                }

                Console.Write("\r\n");
            }

            Result totalTopResult = null;

            for (var i = 0; i < baseSearchEngines.Length; i++)
            {
                var baseSearchEngine = baseSearchEngines[i];
                var topResult = baseSearchEngine.GetTopResult();
                var request = baseSearchEngine.GetRequest();

                if (totalTopResult == null || totalTopResult.Number < topResult.Number)
                {
                    totalTopResult = topResult;
                }

                Console.Write($"{request.Title} winner: {topResult.Text}");
                Console.Write("\r\n");
            }
            return totalTopResult;
        }
    }
}
