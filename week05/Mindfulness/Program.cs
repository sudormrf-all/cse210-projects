/*
    Enhancements beyond core requirements:

    1. Progress Tracker:
       - Tracks and displays the number of completed sessions for each activity type.

    2. Randomized Mindfulness Prompts:
       - Each activity presents a random prompt for variety.

    3. Reusable Animation System:
       - Shared spinner and countdown animations across all activities.

    4. Flexible Duration Handling:
       - Base class handles timing logic and user input for duration.

    These features are not required by the assignment but demonstrate additional effort and learning.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var activityLog = new Dictionary<string, int>
        {
            { "Breathing", 0 },
            { "Reflection", 0 },
            { "Listing", 0 }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");

            string choice = Console.ReadLine();
            Activity activity = null;
            string activityName = "";

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    activityName = "Breathing";
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    activityName = "Reflection";
                    break;
                case "3":
                    activity = new ListingActivity();
                    activityName = "Listing";
                    break;
                case "4":
                    Console.WriteLine("\nSession Summary:");
                    foreach (var entry in activityLog)
                    {
                        Console.WriteLine($"{entry.Key} Activity: {entry.Value} time(s)");
                    }
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.ReadKey();
                    continue;
            }

            activity.Run();
            activityLog[activityName]++;
        }
    }
}
