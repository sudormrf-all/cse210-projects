using System;

public class Program
{
    public static void Main()
    {
        var manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\nEternal Quest - Main Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Progress");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    RecordProgress(manager);
                    break;
                case "4":
                    manager.SaveGoals("goals.json");
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case "5":
                    manager.LoadGoals("goals.json");
                    Console.WriteLine("Goals loaded successfully!");
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nGoal Types:");
        Console.WriteLine("1. Simple Goal (one-time)");
        Console.WriteLine("2. Eternal Goal (repeating)");
        Console.WriteLine("3. Checklist Goal (multiple times)");
        Console.Write("Select goal type: ");

        var typeChoice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        var name = Console.ReadLine();
        Console.Write("Enter description: ");
        var desc = Console.ReadLine();
        Console.Write("Enter base points: ");
        var points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                manager.CreateGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.CreateGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target completions: ");
                var target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                var bonus = int.Parse(Console.ReadLine());
                manager.CreateGoal(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type. Returning to menu.");
                return;
        }

        Console.WriteLine("Goal created successfully! Press Enter to continue...");
        Console.ReadLine();
    }

    private static void RecordProgress(GoalManager manager)
    {
        manager.DisplayGoals();
        if (manager.GoalCount == 0) return;

        Console.Write("Enter goal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= manager.GoalCount)
        {
            manager.RecordEvent(index - 1);
            Console.WriteLine("Progress recorded! New score: " + manager.Score);
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
        Console.ReadLine();
    }
}