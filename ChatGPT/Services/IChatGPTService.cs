using System;
using OutSystems.ExternalLibraries.SDK;

namespace ChatGPT
{
    [OSInterface(Description = "Get sentiment analysis from text input", IconResourceName = "ChatGPT.resources.astolfoApp_128.png")]
    public interface IChatGPTService
    {
        [OSAction]
        string GetSentimentAnalysis(string apiKey, string text);
    }
}