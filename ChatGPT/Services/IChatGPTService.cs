using OutSystems.ExternalLibraries.SDK;

namespace ChatGPT
{
    [OSInterface]
    public interface IChatGPTService
    {
        [OSAction(Description = "Get sentiment analysis from text input")]
        string GetSentimentAnalysis(string apiKey, string text);
    }
}