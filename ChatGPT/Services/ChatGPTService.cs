using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ChatGPT;

public class ChatGPTService : IChatGPTService
{
    public string GetSentimentAnalysis(string apiKey, string text)
    {
        var chatGPTRequest = new ChatGPTRequest(apiKey);

        var response = Task.Run(async () => await chatGPTRequest.ChatGPTResponseAsync(text)).Result;

        if (!response.StartsWith("Erro:"))
        {
            // Processa a resposta JSON
            var responseJson = JObject.Parse(response);
            var sentimentResponse = responseJson["choices"][0]["message"]["content"].ToString();

            // Inferindo o sentimento
            var sentiment = sentimentResponse.Contains("positivo") ? "Sentimento positivo"
                            : sentimentResponse.Contains("negativo") ? "Sentimento negativo"
                            : "Sentimento neutro";

            // Retorna o sentimento e o conteúdo em uma única string
            return $"Sentimento: {sentiment}, Conteúdo: {sentimentResponse}";
        }
        else
        {
            return "Erro ao analisar o sentimento: " + response;
        }
    }
}