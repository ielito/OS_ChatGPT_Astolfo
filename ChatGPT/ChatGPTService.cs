using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using ChatGPT;

public class ChatGPTService : IChatGPTService
{
    public string GetSentimentAnalysis(string apiKey, string text)
    {
        var chatGPTRequest = new ChatGPTRequest(apiKey);

        var response = Task.Run(async () => await chatGPTRequest.ChatGPTResponseAsync(text)).Result;

        if (!response.StartsWith("Erro:"))
        {
            // Processando a resposta JSON para extrair a análise de sentimento
            var responseJson = JObject.Parse(response);
            var sentimentResponse = responseJson["choices"][0]["message"]["content"].ToString();

            // Inferindo o sentimento com base no conteúdo da resposta
            // Esta é uma forma simples e não robusta de análise de sentimentos
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
            return "Erro ao analisar o sentimento: " + response;
        }
    }
}
