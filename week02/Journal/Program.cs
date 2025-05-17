// Name: André Duarte Santos de Pina
// Class: CSE 210: Programming with Classes
// W02 Project: Journal Program
// Program.cs
/*
 * Enhanced Features as per personal research:
 * - Mood tracking for each entry
 * - Automatic backup system
 * - Daily journaling reminders
 * - Error handling for file operations
 * - CSV format with proper escaping
 */
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        ShowReminder(journal);

        while (running)
        {
            Console.WriteLine("\nJournal Program Menu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            switch (Console.ReadLine())
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    ShowReminder(journal);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void ShowReminder(Journal journal)
    {
        if (!journal.HasEntryForToday())
        {
            Console.WriteLine("\nREMINDER: You haven't written an entry today!");
        }
    }
}