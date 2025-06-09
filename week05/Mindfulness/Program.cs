/*
Mindfulness Program
Enhancements:
- Activity tracking system that records usage statistics
- Session summary displayed on exit
- Improved input validation
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
