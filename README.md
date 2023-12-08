# ChatGPT Integration for OutSystems

## Overview

This project integrates ChatGPT, an advanced language model developed by OpenAI, with the OutSystems platform. The integration enables OutSystems applications to leverage the powerful natural language processing capabilities of ChatGPT, allowing for sentiment analysis and other AI-driven functionalities within OutSystems applications.

## Features

- **Sentiment Analysis**: Analyze the sentiment of user input text and get responses indicating whether the sentiment is positive, negative, or neutral.
- **Natural Language Processing**: Utilize the GPT-3.5 model for processing and understanding natural language inputs.
- **Customizable**: Easy to customize and extend based on specific use cases.

## How It Works

The integration is achieved through a C# library that interfaces with the OpenAI API, sending requests and receiving responses from the ChatGPT model. This library is then wrapped within OutSystems actions, making it accessible to OutSystems applications.

### Components

- **ChatGPTRequest**: A C# class responsible for sending requests to the OpenAI API.
- **ChatGPTResponse**: A C# class that handles responses from the OpenAI API.
- **IChatGPTService**: An OutSystems interface defining the actions available for OutSystems applications.
- **ChatGPTService**: An implementation of the IChatGPTService interface in C#, providing the logic for interacting with the ChatGPT model.

### Setting Up

1. **API Key**: Obtain an API key from OpenAI.
2. **C# Library**: Implement the ChatGPTRequest and ChatGPTResponse classes in C#.
3. **OutSystems Integration**: Define the IChatGPTService interface and ChatGPTService class in OutSystems, matching the C# implementation.
4. **Usage**: Use the integrated actions within your OutSystems applications to interact with ChatGPT.

## Requirements

- OutSystems Development Environment.
- Access to OpenAI API with a valid API key.
- .NET compatibility for C# integration.

## Installation

1. Clone the repository to your local machine.
2. Add your OpenAI API key to the `ChatGPTRequest` class.
3. Build the C# project and ensure all dependencies are resolved.
4. Import the built library into your OutSystems application.
5. Use the provided actions in your OutSystems logic flows.

## Example Usage

To perform sentiment analysis:

```csharp
var chatGPTClient = new ChatGPTRequest("your_api_key");
string userInput = "Your input text here";
var sentiment = await chatGPTClient.GetSentimentAnalysisAsync(userInput);
Console.WriteLine("Sentiment: " + sentiment);
