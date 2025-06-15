public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _target;
    private int _completed;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent() => _completed = Math.Min(_completed + 1, _target);
    public override bool IsComplete() => _completed >= _target;

    public override int GetPoints() =>
        base.GetPoints() + (IsComplete() ? _bonus : 0);

    public override string GetDetailsString() =>
        $"{_shortName}: {_description} ({_points} points + {_bonus} bonus) [{_completed}/{_target}]";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_completed}";
}
