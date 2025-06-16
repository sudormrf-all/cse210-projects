public class Swimming : Activity
{
    private readonly int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() =>
        _laps * LapLengthMeters * MetersToMiles;

    public override double GetSpeed() =>
        (GetDistance() / base.GetMinutes()) * 60;

    public override double GetPace() =>
        base.GetMinutes() / GetDistance();
}
