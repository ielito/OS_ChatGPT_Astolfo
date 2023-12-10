using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using ChatGPT;

public class ChatGPTService : IChatGPTService
{
    public async Task<string> GetSentimentAnalysisAsync(string apiKey, string text)
    {
        var chatGPTRequest = new ChatGPTRequest(apiKey);

        var response = await chatGPTRequest.ChatGPTResponseAsync(text);

        return AnalyzeSentiment(response);
    }

    public string GetSentimentAnalysis(string apiKey, string text)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        if (text == null) throw new ArgumentNullException(nameof(text));

        var chatGPTRequest = new ChatGPTRequest(apiKey);

        // Chama a API e aguarda a resposta
        var response = Task.Run(async () => await chatGPTRequest.ChatGPTResponseAsync(text)).Result;

        // Analisa a resposta e retorna o sentimento
        return AnalyzeSentiment(response);
    }

    private string AnalyzeSentiment(string apiResponse)
    {
        if (!apiResponse.StartsWith("Erro:"))
        {

            // Processa a resposta JSON
            var responseJson = JObject.Parse(apiResponse);
            var sentimentResponse = responseJson["choices"][0]["message"]["content"].ToString();

            // Realiza a análise de sentimento
            if (sentimentResponse.Contains("feliz") || sentimentResponse.Contains("positivo"))
            {
                return "Sentimento positivo";
            }
            else if (sentimentResponse.Contains("triste") || sentimentResponse.Contains("negativo"))
            {
                return "Sentimento negativo";
            }
            else
            {
                return "Sentimento neutro";
            }
        }
        else
        {
            return "Erro ao analisar o sentimento: " + apiResponse;
        }
    }
}
