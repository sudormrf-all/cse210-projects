public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent() => _timesCompleted++;
    public override bool IsComplete() => false;

    public override string GetDetailsString() =>
        $"{_shortName}: {_description} ({_points} points per completion) [Completed {_timesCompleted}x]";

    public override string GetStringRepresentation() =>
        $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";
}
