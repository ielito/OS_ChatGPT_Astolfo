using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class ChatGPTRequest
    {
        private readonly string apiKey;
        private readonly HttpClient httpClient;

        public ChatGPTRequest(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient = new HttpClient();
        }

        public async Task<string> ChatGPTResponseAsync(string userInput)
        {
            var requestUrl = "https://api.openai.com/v1/chat/completions"; // URL correta
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                temperature = 0,
                messages = new[] {
            new {
                role = "system",
                content = "As an AI with expertise in language and emotion analysis, your task is to analyze the sentiment of the following text. Please consider the overall tone of the discussion, the emotion conveyed by the language used, and the context in which words and phrases are used. Indicate whether the sentiment is generally positive, negative, or neutral, and provide brief explanations for your analysis where possible."
            },
            new {
                role = "user",
                content = userInput
            }
        },
                max_tokens = 60 // Ajuste conforme necessário
            };

            var jsonRequest = System.Text.Json.JsonSerializer.Serialize(requestBody);
            Console.WriteLine("Requisição JSON: " + jsonRequest); // Log do JSON da requisição

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            // Log da chave da API
            Console.WriteLine("Chave da API: " + apiKey);

            var response = await httpClient.PostAsync(requestUrl, content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse; // Resposta JSON da API
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Erro na resposta: " + errorResponse); // Log da resposta em caso de erro
                return "Erro: {response.StatusCode}";
            }
        }
    }
}
