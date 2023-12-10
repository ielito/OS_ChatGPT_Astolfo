using System;

namespace ChatGPT
{
    public class ChatGPTResponse
    {
        // Conteúdo da resposta da API
        public string Content { get; private set; }

        // Indica se a chamada à API foi bem-sucedida
        public bool IsSuccess { get; private set; }

        // Mensagem de erro, se houver
        public string ErrorMessage { get; private set; }

        // Construtor para casos de sucesso
        public ChatGPTResponse(string content)
        {
            IsSuccess = true;
            Content = content;
            ErrorMessage = string.Empty;
        }

        // Construtor para casos de erro
        public ChatGPTResponse(string errorMessage, bool isSuccess)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Content = string.Empty;
        }
    }
}
