public abstract class Activity
{
    private readonly DateTime _date;
    private readonly int _minutes;

    protected Activity(string date, int minutes)
    {
        _date = DateTime.Parse(date);
        _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, " +
               $"Pace: {GetPace():0.0} min per mile";
    }

    protected int GetMinutes() => _minutes;
}
