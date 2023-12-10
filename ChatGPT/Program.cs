using System;
using System.Threading.Tasks;
using ChatGPT;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Digite a chave da API:");
        var apiKey = Console.ReadLine();

        // Adicione a verificação aqui
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("API Key não pode ser vazia.");
            return;
        }

        Console.WriteLine("Digite o texto para análise:");
        var userInput = Console.ReadLine();

        await TestarChatGPTAsync(apiKey, userInput);
    }

    static async Task TestarChatGPTAsync(string apiKey, string userInput)
    {
        var chatGPTService = new ChatGPTService();

        // Chama o método para obter a análise de sentimento
        var sentimentAnalysisResult = chatGPTService.GetSentimentAnalysis(apiKey, userInput);

        // Verifica se a resposta começa com "Erro:"
        if (!sentimentAnalysisResult.StartsWith("Erro:"))
        {
            Console.WriteLine("Análise de Sentimento: " + sentimentAnalysisResult);
        }
        else
        {
            Console.WriteLine("Erro na análise de sentimento: " + sentimentAnalysisResult);
        }
    }
}
