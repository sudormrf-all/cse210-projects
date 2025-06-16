class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),
            new Cycling("03 Nov 2022", 30, 18.6), // 6 mph converted to kph if needed
            new Swimming("03 Nov 2022", 30, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
