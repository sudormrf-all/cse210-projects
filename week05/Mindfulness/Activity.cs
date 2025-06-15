using System;
using System.Threading;

/*
    Activity.cs

    Base class for all mindfulness activities.

    Enhancements:
    - Handles flexible duration input and timing.
    - Provides reusable spinner and countdown animations for all activities.
*/

public class Activity
{
    protected int _duration;
    private string _name;
    private string _description;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity");
        ShowSpinner(3);
    }

    // Enhancement: Reusable spinner animation
    protected void ShowSpinner(int seconds)
    {
        string[] animations = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            foreach (string symbol in animations)
            {
                Console.Write(symbol);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }

    // Enhancement: Reusable countdown animation
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run()
    {
        DisplayStartingMessage();
        DisplayEndingMessage();
    }
}
