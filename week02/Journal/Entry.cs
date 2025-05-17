// Name: André Duarte Santos de Pina
// Class: CSE 210: Programming with Classes
// W02 Project: Journal Program
// Entry.cs
public class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }
    public string Mood { get; }

    public Entry(string prompt, string response, string date, string mood)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"[{Date}] Mood: {Mood}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}