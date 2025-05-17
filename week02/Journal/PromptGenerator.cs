// Name: André Duarte Santos de Pina
// Class: CSE 210: Programming with Classes
// W02 Project: Journal Program
// PromptGenerator.cs
using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What experience challenged your perspective today?",
        "What small victory made you proud?",
        "How did you practice self-care today?",
        "What inspired you today?",
        "What would you tell your future self about today?",
        "What are you looking forward to tomorrow?",
        "How did you handle a difficult situation today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}