using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals = new();
    private int _score;

    public int GoalCount => _goals.Count;
    public int Score => _score;

    public void CreateGoal(Goal goal) => _goals.Add(goal);

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"\nTotal Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        var data = new
        {
            Score = _score,
            Goals = _goals.Select(g => g.GetStringRepresentation()).ToList()
        };
        File.WriteAllText(filename, JsonSerializer.Serialize(data));
    }

    public void LoadGoals(string filename)
    {
        var json = File.ReadAllText(filename);
        using var doc = JsonDocument.Parse(json);

        _score = doc.RootElement.GetProperty("Score").GetInt32();
        _goals.Clear();

        foreach (var goalElement in doc.RootElement.GetProperty("Goals").EnumerateArray())
        {
            var parts = goalElement.GetString().Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    var simple = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (bool.Parse(parts[4])) simple.RecordEvent();
                    _goals.Add(simple);
                    break;
                case "EternalGoal":
                    var eternal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    for (int i = 0; i < int.Parse(parts[4]); i++) eternal.RecordEvent();
                    _goals.Add(eternal);
                    break;
                case "ChecklistGoal":
                    var checklist = new ChecklistGoal(
                        parts[1], parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]));
                    for (int i = 0; i < int.Parse(parts[6]); i++) checklist.RecordEvent();
                    _goals.Add(checklist);
                    break;
            }
        }
    }
}
