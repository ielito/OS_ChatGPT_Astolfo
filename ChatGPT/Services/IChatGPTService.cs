using System;
using OutSystems.ExternalLibraries.SDK;

namespace ChatGPT
{
    [OSInterface(Description = "Get sentiment analysis from text input", IconResourceName = "ChatGPT.Request.astolfoApp_128.png")]
    public interface IChatGPTService
    {
        [OSAction]
        string GetSentimentAnalysis(string apiKey, string text);
    }
}