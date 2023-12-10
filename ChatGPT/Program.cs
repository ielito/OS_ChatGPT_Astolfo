using System;
using System.Threading.Tasks;
using ChatGPT;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Digite a chave da API:");
        var apiKey = Console.ReadLine();

        Console.WriteLine("Digite o texto para análise:");
        var userInput = Console.ReadLine();

        await TestarChatGPTAsync(apiKey, userInput);
    }

    static async Task TestarChatGPTAsync(string apiKey, string userInput)
    {
        var chatGPTService = new ChatGPTService();

        var responseContent = chatGPTService.GetSentimentAnalysis(apiKey, userInput);

        // Imprime a resposta
        Console.WriteLine(responseContent);
    }
}
