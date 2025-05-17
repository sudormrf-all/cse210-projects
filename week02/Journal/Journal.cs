// Name: André Duarte Santos de Pina
// Class: CSE 210: Programming with Classes
// W02 Project: Journal Program
// Journal.cs
using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.Write("Today's mood (e.g., happy, anxious, calm): ");
        string mood = Console.ReadLine();
        _entries.Add(new Entry(
            prompt,
            response.Replace("|", "\\|"),  // Escape special characters
            DateTime.Now.ToString("MM/dd/yyyy"),
            mood.Replace("|", "\\|")
        ));
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayEntries()
    {
        Console.WriteLine($"\nJournal Entries ({_entries.Count} total):");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        try
        {
            // Save main file
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Mood}");
                }
            }

            // Create backup
            string backupDir = "backups";
            Directory.CreateDirectory(backupDir);
            string backupFile = Path.Combine(backupDir, $"{DateTime.Now:yyyyMMdd_HHmmss}_backup.txt");
            File.Copy(filename, backupFile);

            Console.WriteLine($"Journal saved to {filename} (backup: {backupFile})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { '|' }, 4);
                if (parts.Length == 4)
                {
                    _entries.Add(new Entry(
                        parts[1],
                        parts[2].Replace("\\|", "|"),  // Unescape
                        parts[0],
                        parts[3].Replace("\\|", "|")
                    ));
                }
            }
            Console.WriteLine($"Loaded {_entries.Count} entries from {filename}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File {filename} not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public bool HasEntryForToday()
    {
        string today = DateTime.Now.ToString("MM/dd/yyyy");
        return _entries.Exists(entry => entry.Date == today);
    }
}
