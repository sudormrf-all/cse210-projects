public class Running : Activity
{
    private readonly double _distance;

    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / base.GetMinutes()) * 60;
    public override double GetPace() => base.GetMinutes() / _distance;
}
