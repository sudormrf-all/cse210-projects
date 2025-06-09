public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public override void Run()
    {
        base.DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");
            ShowCountdown(4);
            breatheIn = !breatheIn;
        }

        base.DisplayEndingMessage();
    }
}
