public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent() => _isComplete = true;
    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString() =>
        $"[{(_isComplete ? "X" : " ")}] {_shortName}: {_description} ({_points} points)";

    public override string GetStringRepresentation() =>
        $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
}
