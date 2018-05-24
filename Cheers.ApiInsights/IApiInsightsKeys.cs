namespace Cheers.ApiInsights
{
    public interface IApiInsightsKeys
    {
        string StopWatchName { get; }
        string StartTimeName { get; }

    }
    public class ApiInsightsKeys : IApiInsightsKeys
    {
        public ApiInsightsKeys(string stopWatchName,string startTimeName)
        {
            StopWatchName = stopWatchName;
            StartTimeName = startTimeName;
        }
        public string StopWatchName { get; set; }

        public string StartTimeName { get; set; }
    }
}
