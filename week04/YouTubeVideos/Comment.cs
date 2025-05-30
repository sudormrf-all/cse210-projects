public class Comment
{
    public string CommenterName { get; }
    public string Text { get; }

    public Comment(string name, string text)
    {
        CommenterName = name;
        Text = text;
    }
}
