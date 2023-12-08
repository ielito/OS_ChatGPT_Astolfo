using System;

namespace ChatGPT
{
    public class ChatGPTResponse
    {
        public string ResponseContent { get; private set; }
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }

        public ChatGPTResponse(string response, bool isSuccess)
        {
            IsSuccess = isSuccess;

            if (isSuccess)
            {
                ResponseContent = response;
            }
            else
            {
                ErrorMessage = response;
            }
        }
    }
}