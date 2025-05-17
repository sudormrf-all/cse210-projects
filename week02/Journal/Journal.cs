// Name: André Duarte Santos de Pina
// Class: CSE 210: Programming with Classes
// W02 Project: Journal Program
// Journal.cs (CSV for Excel)
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
        Console.Write("Today's mood: ");
        string mood = Console.ReadLine();

        _entries.Add(new Entry(
            prompt,
            response,
            DateTime.Now.ToString("MM/dd/yyyy"),
            mood
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

    // Save to CSV (Excel-friendly)
    public void SaveToCsv()
    {
        Console.Write("Enter filename to save (e.g., journal.csv): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Write CSV header
                writer.WriteLine("Date,Prompt,Response,Mood");
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(string.Join(",",
                        EscapeCsv(entry.Date),
                        EscapeCsv(entry.Prompt),
                        EscapeCsv(entry.Response),
                        EscapeCsv(entry.Mood)
                    ));
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
    }

    // Load from CSV (Excel-friendly)
    public void LoadFromCsv()
    {
        Console.Write("Enter filename to load (e.g., journal.csv): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                _entries.Clear();
                string header = reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = ParseCsvLine(line);
                    if (fields.Length == 4)
                    {
                        _entries.Add(new Entry(
                            fields[1],
                            fields[2],
                            fields[0],
                            fields[3]
                        ));
                    }
                }
            }
            Console.WriteLine($"Loaded {_entries.Count} entries from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }
    }

    // Returns true if an entry exists for today
    public bool HasEntryForToday()
    {
        string today = DateTime.Now.ToString("MM/dd/yyyy");
        return _entries.Exists(entry => entry.Date == today);
    }

    // Properly escape a field for CSV
    private string EscapeCsv(string field)
    {
        if (field == null)
            return "";
        bool mustQuote = field.Contains(",") || field.Contains("\"") || field.Contains("\r") || field.Contains("\n");
        string result = field.Replace("\"", "\"\"");
        if (mustQuote)
            result = $"\"{result}\"";
        return result;
    }

    // Properly parse a CSV line into fields (handles quotes and commas)
    private string[] ParseCsvLine(string line)
    {
        var fields = new List<string>();
        bool inQuotes = false;
        string field = "";
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        field += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    field += c;
                }
            }
            else
            {
                if (c == ',')
                {
                    fields.Add(field);
                    field = "";
                }
                else if (c == '"')
                {
                    inQuotes = true;
                }
                else
                {
                    field += c;
                }
            }
        }
        fields.Add(field);
        return fields.ToArray();
    }
}
