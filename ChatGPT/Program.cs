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

        // Aqui, consideramos a resposta bem-sucedida se não começar com "Erro:"
        var isSuccess = !responseContent.StartsWith("Erro:");
        var response = new ChatGPTResponse(responseContent, isSuccess);

        if (response.IsSuccess)
        {
            Console.WriteLine("Resposta do ChatGPT: " + response.ResponseContent);
        }
        else
        {
            Console.WriteLine("Erro na resposta: " + response.ErrorMessage);
        }
    }
}
