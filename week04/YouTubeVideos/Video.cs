using System.Collections.Generic;

public class Video
{
    public string Title { get; }
    public string Author { get; }
    public int LengthSeconds { get; }
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public IEnumerable<Comment> GetComments()
    {
        return _comments;
    }
}
