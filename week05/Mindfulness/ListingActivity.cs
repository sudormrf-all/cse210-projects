using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        var random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        Console.Write("Starting in... ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            itemCount++;
        }

        Console.WriteLine($"You listed {itemCount} items!");
        DisplayEndingMessage();
    }
}
